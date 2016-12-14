using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class AttackScript : MonoBehaviour {

    private SpriteRenderer sr;
    public bool left;
    Canvas c;

    void Start ()
    {
        c = GameObject.Find("Canvas").GetComponent<Canvas>();
        if (gameObject.name.Contains("Hench"))
        {
            foreach (EnemyMoveScript e in FindObjectsOfType(typeof(EnemyMoveScript)) as EnemyMoveScript[])
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), e.GetComponent<Collider2D>());
            }
        }
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (sr.isVisible)
        {
            if (transform.gameObject.name.Contains("Hench"))
            {
                if (left)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                    transform.Translate(-0.25f, 0, 0);
                }
                else
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                    transform.Translate(0.25f, 0, 0);
                }
            }
            else {
                if (left)
                {
                    transform.Translate(-0.5f, 0, 0);
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    transform.Translate(0.5f, 0, 0);
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D col) {
        if ((col.gameObject.name.Contains("Enemy") || col.gameObject.name.Contains("Trash")) && !gameObject.name.Contains("Hench")) {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            GameObject.Find("Player").GetComponent<PlayerMoveScript>().AddScore();
        }
        if (col.gameObject.name.Contains("Chief") && !gameObject.name.Contains("Hench"))
        {
            Destroy(this.gameObject);
            col.gameObject.GetComponent<BigChiefMoveScript>().Damage();
            GameObject.Find("Player").GetComponent<PlayerMoveScript>().AddScore();
        }
        if (col.gameObject.name.Contains("Player") && gameObject.name.Contains("Hench"))
        {
            if (GameObject.Find("Health").GetComponent<RectTransform>().position.x > -50)
            {
                GameObject.Find("Player").GetComponent<PlayerMoveScript>().ReduceScore();
                GameObject.Find("Health").GetComponent<RectTransform>().position -= new Vector3(50 * c.scaleFactor, 0, 0);
            }
            else
            {
                PlayerPrefs.SetInt("tempHigh", col.gameObject.GetComponent<PlayerMoveScript>().playerScore);
                Destroy(col.gameObject);
                SceneManager.LoadScene("High Scores");
            }
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D (Collider2D col)
    {
        if (!gameObject.name.Contains("Hench"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}

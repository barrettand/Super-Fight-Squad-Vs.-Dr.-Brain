using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackScript : MonoBehaviour {

    private SpriteRenderer sr;
    public bool left;

    void Start ()
    {
        if (gameObject.name.Contains("Hench"))
        {
            foreach (EnemyMoveScript e in FindObjectsOfType(typeof(EnemyMoveScript)) as EnemyMoveScript[])
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), e.GetComponent<Collider2D>());
            }
        }
        else
        {
            foreach (PlayerMoveScript p in FindObjectsOfType(typeof(PlayerMoveScript)) as PlayerMoveScript[])
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), p.GetComponent<Collider2D>());
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
                }
                else
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
                transform.Translate(-0.25f, 0, 0);
            }
            else {
                if (left)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }
                transform.Translate(0.5f, 0, 0);
            }
        }
        else
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name.Contains("Enemy") && !gameObject.name.Contains("Hench")) {
            GameObject.Find("Player").GetComponent<PlayerMoveScript>().opponent = null;
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            GameObject.Find("Player").GetComponent<PlayerMoveScript>().AddScore();
        }
        if (col.gameObject.name.Contains("Player") && gameObject.name.Contains("Hench"))
        {
            if (GameObject.Find("Health").GetComponent<RectTransform>().position.x > -142 && (transform.position.y > col.gameObject.transform.position.y - 0.5 || transform.position.y < col.gameObject.transform.position.y + 0.5))
            {
                GameObject.Find("Health").GetComponent<RectTransform>().position -= new Vector3(10, 0, 0);
            }
            else {
                Destroy(col.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

}

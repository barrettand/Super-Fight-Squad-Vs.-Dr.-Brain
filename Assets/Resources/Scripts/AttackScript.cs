using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackScript : MonoBehaviour {

    private SpriteRenderer sr;
    public bool left;

    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (sr.isVisible)
        {
            if (left)
            {
                transform.Translate(-0.5f, 0, 0);
            }
            else
            {
                transform.Translate(0.5f, 0, 0);
            }
        }
        else
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name.Contains("Enemy") && !this.gameObject.name.Contains("Hench")) {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            GameObject.Find("Player").GetComponent<PlayerMoveScript>().AddScore();
        }
        if (col.gameObject.name.Contains("Player") && this.gameObject.name.Contains("Hench"))
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

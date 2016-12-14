using UnityEngine;
using System.Collections;

public class BigChiefMoveScript : MonoBehaviour {

    GameObject player;
    GameObject health, bar;
	// Use this for initialization
	void Start () {
        health = GameObject.Find("BossHealth");
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > player.transform.position.x + 2)
        {
            GetComponent<Animator>().SetBool("InRange", false);
            transform.Translate(-0.05f, 0, 0);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        if (transform.position.y > player.transform.position.y + 1.5)
        {
            GetComponent<Animator>().SetBool("InRange", false);
            transform.Translate(0, -0.05f, 0);
        }
        if (transform.position.y < player.transform.position.y + 1.5)
        {
            GetComponent<Animator>().SetBool("InRange", false);
            transform.Translate(0, 0.05f, 0);
        }
        if (transform.position.x < player.transform.position.x - 2)
        {
            GetComponent<Animator>().SetBool("InRange", false);
            transform.Translate(0.05f, 0, 0);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        if (transform.position.x <= player.transform.position.x + 2 && transform.position.x >= player.transform.position.x)
        {
            GetComponent<Animator>().SetBool("InRange", true);
            transform.Translate(0.05f, 0, 0);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        if (transform.position.x >= player.transform.position.x - 2 && transform.position.x <= player.transform.position.x)
        {
            GetComponent<Animator>().SetBool("InRange", true);
            transform.Translate(-0.05f, 0, 0);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Damage() {
        if (health.GetComponent<RectTransform>().position.x < 666) {
            health.GetComponent<RectTransform>().position += new Vector3(25 * GameObject.Find("Canvas").GetComponent<Canvas>().scaleFactor, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class TrashEnemyMoveScript : MonoBehaviour {
    public GameObject player;
    public Vector3 target = new Vector3(0,0,0), currentLoc;
    float bounceDelay = 1f;
    public float bounceTimer = 0, animTime = 0;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        animTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<SpriteRenderer>().isVisible)
        {
            bounceTimer += Time.deltaTime;
        }
        if (bounceTimer >= bounceDelay) {
            if (target == new Vector3(0,0,0) && transform.position != player.transform.position)
            {
                target = player.transform.position;
                GetComponent<Animator>().SetBool("HopStart", true);
                GetComponent<Animator>().SetBool("Land", false);
            }
            currentLoc = Vector3.Lerp(transform.position, target, animTime);
            currentLoc.y += (1 * Mathf.Sin(Mathf.Clamp01(animTime*10) * Mathf.PI));
            transform.position = currentLoc;
            animTime += 0.005f;
            if (Mathf.Round(animTime * 10) == 1)
            {
                GetComponent<Animator>().SetBool("HopEnd", true);
                GetComponent<Animator>().SetBool("HopStart", false);
            }
            if (transform.position == target)
            {
                GetComponent<Animator>().SetBool("HopEnd", false);
                GetComponent<Animator>().SetBool("Land", true);
                bounceTimer = 0;
                animTime = 0;
                target = new Vector3(0, 0, 0);
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {
    public GameObject player, bullet;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < player.transform.position.x - 2)
        {
            transform.Translate(0.05f, 0, 0);
        }
        if (transform.position.x > player.transform.position.x + 2)
        {
            transform.Translate(-0.05f, 0, 0);
        }
        if (transform.position.y < player.transform.position.y)
        {
            transform.Translate(0, 0.05f, 0);
        }
        if (transform.position.y > player.transform.position.y)
        {
            transform.Translate(0, -0.05f, 0);
        }
        if (transform.position.y == player.transform.position.y && (transform.position.x >= player.transform.position.x - 2) || (transform.position.x <= player.transform.position.x + 2)) {
            if (bullet.transform.position.x <= transform.position.x + 2)
            {
                bullet.transform.Translate(0.1f, 0, 0);
            }
        }
    }
}

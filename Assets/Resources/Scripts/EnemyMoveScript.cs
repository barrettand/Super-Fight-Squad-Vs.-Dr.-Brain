using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {
    public GameObject player, bullet;
    float shootDelay = 0.5f;
    private float shootTimer = 0;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        shootTimer += Time.deltaTime;

        if (transform.position.x < player.transform.position.x - 2)
        {
            transform.Translate(0.05f, 0, 0);
            bullet.GetComponent<AttackScript>().left = false;
        }
        if (transform.position.x > player.transform.position.x + 2)
        {
            transform.Translate(-0.05f, 0, 0);
            bullet.GetComponent<AttackScript>().left = true;
        }
        if (transform.position.y < player.transform.position.y)
        {
            transform.Translate(0, 0.05f, 0);
        }
        if (transform.position.y > player.transform.position.y)
        {
            transform.Translate(0, -0.05f, 0);
        }
        if ((transform.position.y > player.transform.position.y - 1 || transform.position.y < player.transform.position.y + 1) && shootTimer >= shootDelay)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shootTimer = 0;
        }
    }
}

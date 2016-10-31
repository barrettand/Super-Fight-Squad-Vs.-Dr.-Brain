using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {
    public GameObject player, bullet;
    PlayerMoveScript[] players;
    float shootDelay = 0.5f;
    private float shootTimer = 0;
    // Use this for initialization
    void Start () {
        players = FindObjectsOfType(typeof(PlayerMoveScript)) as PlayerMoveScript[];
        for (int x = 0; x < players.Length; x++)
        {
            if (players[x].opponent == null && players.Length > 1)
            {
                players[x].opponent = this as EnemyMoveScript;
                player = players[x].gameObject;
                break;
            }
            else if(players.Length == 1)
            {
                player = players[x].gameObject;
            }
        }
        if (player == null) {
            bool eq = false;
            for (int x = 0; x < players.Length; x++)
            {
                if (players[x].opponent == null)
                {
                    eq = eq && true;
                }
                else
                {
                    eq = eq && false;
                    break;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        shootTimer += Time.deltaTime;

        if (transform.position.x < player.transform.position.x - 2)
        {
            transform.Translate(-0.05f, 0, 0);
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            bullet.GetComponent<AttackScript>().left = false;
        }
        if (transform.position.x > player.transform.position.x + 2)
        {
            transform.Translate(-0.05f, 0, 0);
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
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
        if ((transform.position.y > player.transform.position.y - 1 && transform.position.y < player.transform.position.y + 1) && shootTimer >= shootDelay)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shootTimer = 0;
        }
    }
}

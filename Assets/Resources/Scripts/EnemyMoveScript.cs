﻿using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {
    public GameObject player, bullet;
    float shootDelay = 0.5f;
    private float shootTimer = 0;
    bool running = false;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<SpriteRenderer>().isVisible)
        {
            shootTimer += Time.deltaTime;
        }

        if ((transform.position.y > player.transform.position.y - 0.1f && transform.position.y < player.transform.position.y + 0.1f && GetComponent<SpriteRenderer>().isVisible) || shootTimer >= shootDelay)
        {
            if (!running)
            {
                StartCoroutine(shoot());
                shootTimer = 0;
            }
        }
        else
        {
            StopCoroutine(shoot());
            if (transform.position.x < player.transform.position.x)
            {
                if (transform.position.x < player.transform.position.x - 3)
                {
                    transform.Translate(0.05f, 0, 0);
                }
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                bullet.GetComponent<AttackScript>().left = false;
            }
            if (transform.position.x > player.transform.position.x)
            {
                if (transform.position.x > player.transform.position.x + 3)
                {
                    transform.Translate(-0.05f, 0, 0);
                }
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
        }
    }
    IEnumerator shoot() {
        running = true;
        yield return new WaitForSeconds(0.5f);
        if (transform.position.x > player.transform.position.x)
        {
            GameObject b = Instantiate(bullet, transform.position - new Vector3(1, 0, 0), transform.rotation) as GameObject;
            b.GetComponent<AttackScript>().left = true;
            b.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GameObject b = Instantiate(bullet, transform.position + new Vector3(1, 0, 0), transform.rotation) as GameObject;
            b.GetComponent<AttackScript>().left = false;
            b.transform.localScale = new Vector3(-1, 1, 1);
        }
        yield return new WaitForSeconds(1f);
        running = false;
    }
}

﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraMove : MonoBehaviour {

    GameObject player;
    Camera cam;
    bool stopped = true;
    bool spawned = false;
    bool spawned1 = false;
    bool spawned2 = false;
    GameObject GO;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        cam = Camera.main;
        GO = GameObject.Find("GO");
        GO.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (!stopped) {
            GO.SetActive(true);
        }
        else
        {
            GO.SetActive(false);
        }
        if (cam.transform.position.x == 0 && FindObjectsOfType<EnemyMoveScript>().Length > 0)
        {
            stopped = true;
        }
        else if (Mathf.Round(cam.transform.position.x) == 10 && FindObjectsOfType<EnemyMoveScript>().Length == 0 && !spawned)
        {
            stopped = true;
            int r = Random.Range(0, 2);
            if (r == 0) {
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 10, cam.transform.position.y, 0), cam.transform.rotation);
            }
            else if(r == 1)
            {
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 10, cam.transform.position.y, 0), cam.transform.rotation);
            }
            else {
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 10, cam.transform.position.y + 2, 0), cam.transform.rotation);
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 10, cam.transform.position.y + 2, 0), cam.transform.rotation);
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 10, cam.transform.position.y - 2, 0), cam.transform.rotation);
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 10, cam.transform.position.y - 2, 0), cam.transform.rotation);

            }
        }
        else if (Mathf.Round(cam.transform.position.x) == 10 && FindObjectsOfType<EnemyMoveScript>().Length > 0)
        {
            stopped = true;
            spawned = true;
        }
        else if (Mathf.Round(cam.transform.position.x) == 20 && FindObjectsOfType<EnemyMoveScript>().Length == 0 && !spawned1)
        {
            stopped = true;
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 10, cam.transform.position.y, 0), cam.transform.rotation);
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 10, cam.transform.position.y, 0), cam.transform.rotation);
            }
            else if (r == 1)
            {
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 10, cam.transform.position.y - 1, 0), cam.transform.rotation);
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 10, cam.transform.position.y + 1, 0), cam.transform.rotation);
            }
            else
            {
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 10, cam.transform.position.y + 2, 0), cam.transform.rotation);
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 10, cam.transform.position.y + 2, 0), cam.transform.rotation);
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 10, cam.transform.position.y - 2, 0), cam.transform.rotation);
                Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 10, cam.transform.position.y - 2, 0), cam.transform.rotation);

            }
        }
        else if (Mathf.Round(cam.transform.position.x) == 20 && FindObjectsOfType<EnemyMoveScript>().Length > 0)
        {
            stopped = true;
            spawned1 = true;
        }
        else if (Mathf.Round(cam.transform.position.x) == 40 && FindObjectsOfType<BigChiefMoveScript>().Length == 0 && !spawned2)
        {
            stopped = true;
            Instantiate(Resources.Load("Prefabs/Big Chief"), new Vector3(cam.transform.position.x + 10, cam.transform.position.y + 2, 0), cam.transform.rotation);
                
        }
        else if (Mathf.Round(cam.transform.position.x) == 40 && FindObjectsOfType<BigChiefMoveScript>().Length > 0)
        {
            stopped = true;
            spawned2 = true;
        }
        else {
            stopped = false;
        }
        if (player.transform.localPosition.x > 0 && cam.transform.position.x <= 42.2 && !stopped) {
            if (player.transform.localPosition.x > 0)
            {
                player.transform.localPosition = new Vector3(player.transform.localPosition.x - 0.1f, player.transform.localPosition.y, player.transform.localPosition.z);
            }
            cam.transform.Translate(0.1f, 0, 0);
        }
        if (cam.transform.position.x >= 42.2)
        {
            GameObject.Find("Cleared").GetComponent<Text>().enabled = true;
        }
        if (cam.transform.position.x >= 42.2 && Input.GetKey(KeyCode.Space) && GameObject.Find("Cleared").GetComponent<Text>().enabled)
        {
            PlayerPrefs.SetInt("tempHigh", player.GetComponent<PlayerMoveScript>().playerScore);
            SceneManager.LoadScene("High Scores");
        }
    }
}

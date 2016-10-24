using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraMove : MonoBehaviour {

    GameObject player;
    Camera cam;
    bool stopped = true;
    bool spawned = false;
    bool spawned1 = false;
    bool spawned2 = false;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        if (cam.transform.position.x == 0 && FindObjectsOfType<EnemyMoveScript>().Length > 0)
        {
            stopped = true;
        }
        else if (Mathf.Round(cam.transform.position.x) == 20 && FindObjectsOfType<EnemyMoveScript>().Length == 0 && !spawned)
        {
            stopped = true;
            Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 8, cam.transform.position.y, 0), cam.transform.rotation);
        }
        else if (Mathf.Round(cam.transform.position.x) == 20 && FindObjectsOfType<EnemyMoveScript>().Length > 0)
        {
            stopped = true;
            spawned = true;
        }
        else if (Mathf.Round(cam.transform.position.x) == 30 && FindObjectsOfType<EnemyMoveScript>().Length == 0 && !spawned1)
        {
            stopped = true;
            Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 8, cam.transform.position.y, 0), cam.transform.rotation);
            Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 8, cam.transform.position.y, 0), cam.transform.rotation);
        }
        else if (Mathf.Round(cam.transform.position.x) == 30 && FindObjectsOfType<EnemyMoveScript>().Length > 0)
        {
            stopped = true;
            spawned1 = true;
        }
        else if (Mathf.Round(cam.transform.position.x) == 40 && FindObjectsOfType<EnemyMoveScript>().Length == 0 && !spawned2)
        {
            stopped = true;
            Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 8, cam.transform.position.y, 0), cam.transform.rotation);
            Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 8, cam.transform.position.y, 0), cam.transform.rotation);
            Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x + 16, cam.transform.position.y, 0), cam.transform.rotation);
            Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(cam.transform.position.x - 16, cam.transform.position.y, 0), cam.transform.rotation);
        }
        else if (Mathf.Round(cam.transform.position.x) == 40 && FindObjectsOfType<EnemyMoveScript>().Length > 0)
        {
            stopped = true;
            spawned2 = true;
        }
        else {
            stopped = false;
        }
        if (player.transform.localPosition.x > 0 && cam.transform.position.x <= 58.1 && !stopped) {
            player.transform.localPosition = new Vector3(0, player.transform.localPosition.y, player.transform.localPosition.z);
            cam.transform.Translate(0.1f, 0, 0);
        }
        if (cam.transform.position.x >= 58.1)
        {
            GameObject.Find("Cleared").GetComponent<Text>().enabled = true;
        }
    }
}

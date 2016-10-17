using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    GameObject player;
    Camera cam;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.localPosition.x > 0 && cam.transform.position.x <= 58.1) {
            player.transform.localPosition = new Vector3(0, player.transform.localPosition.y, player.transform.localPosition.z);
            cam.transform.Translate(0.1f, 0, 0);
        }
    }
}

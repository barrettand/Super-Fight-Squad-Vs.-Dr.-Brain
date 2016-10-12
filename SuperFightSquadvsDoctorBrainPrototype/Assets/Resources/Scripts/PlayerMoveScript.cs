using UnityEngine;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {

    public GameObject fist;
	// Use this for initialization
	void Start () {
        fist.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8)
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8)
        {
            transform.Translate(0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 0)
        {
            transform.Translate(0, 0.1f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -4)
        {
            transform.Translate(0, -0.1f, 0);
        }
        if (Input.GetKey(KeyCode.Space) && fist.transform.position.x < transform.position.x + 2)
        {
            if (!fist.activeSelf)
            {
                fist.SetActive(true);
            }
            fist.transform.Translate(0.5f, 0, 0);
        }
        else
        {
            fist.SetActive(false);
            fist.transform.position = transform.position;
        }
    }
}

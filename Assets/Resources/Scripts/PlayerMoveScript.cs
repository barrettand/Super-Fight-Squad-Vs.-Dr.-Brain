using UnityEngine;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {

    public GameObject bullet;
    public float shootDelay;
    private float shootTimer = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        shootTimer += Time.deltaTime;

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
        if (Input.GetKey(KeyCode.Space) && shootTimer >= shootDelay)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shootTimer = 0;
        }
    }
}

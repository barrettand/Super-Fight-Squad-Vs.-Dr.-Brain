using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {

    public GameObject bullet;
    public float shootDelay;
    private float shootTimer = 0;
    public int playerScore;

	// Use this for initialization
	void Start () {
        bullet.GetComponent<AttackScript>().left = false;
        playerScore = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject.Find("Score").GetComponent<Text>().text = playerScore.ToString();
        shootTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.localScale.x > 0) {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            if (transform.localPosition.x > -7)
            {
                transform.Translate(0.1f, 0, 0);
            }
            bullet.GetComponent<AttackScript>().left = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            if (transform.position.x < 58.1)
            {
                transform.Translate(0.1f, 0, 0);
            }
            bullet.GetComponent<AttackScript>().left = false;
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < -1)
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
    public void AddScore() {
        playerScore += 100;
    }
}

using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

    private SpriteRenderer sr;
    public bool left;

    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (sr.isVisible)
        {
            if (left)
            {
                transform.Translate(-0.5f, 0, 0);
            }
            else
            {
                transform.Translate(0.5f, 0, 0);
            }
        }
        else
        {
            Destroy(gameObject);
        }
	}

}

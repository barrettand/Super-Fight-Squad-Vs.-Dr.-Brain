using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

    private SpriteRenderer sr;

    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (sr.isVisible)
        {
            transform.Translate(0.5f, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
	}

}

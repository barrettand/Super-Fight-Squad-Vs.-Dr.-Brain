using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "";
        for (int x = 0; x < 10; x++)
        {
            if (PlayerPrefs.GetInt("tempHigh") > PlayerPrefs.GetInt("Highscore" + x))
            {
                for (int y = 9; y >= x; y--) {
                    if (y == x) {
                        PlayerPrefs.SetInt("Highscore" + y, PlayerPrefs.GetInt("tempHigh"));
                    }
                    else {
                        PlayerPrefs.SetInt("Highscore" + y, PlayerPrefs.GetInt("Highscore" + (y - 1)));
                    }
                }
                break;
            }
        }
        PlayerPrefs.SetInt("tempHigh", 0);
        for (int x = 0; x < 10; x++)
        {
            GetComponent<Text>().text += (x + 1) + ". " + PlayerPrefs.GetInt("Highscore" + x) + "\n";
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space)) {
            SceneManager.LoadScene("Menu");
        }
	}
}

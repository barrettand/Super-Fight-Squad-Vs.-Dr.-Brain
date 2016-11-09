using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(LoadLevelOne);
	}

    void LoadLevelOne ()
    {
        SceneManager.LoadScene("Level1");
    }
}

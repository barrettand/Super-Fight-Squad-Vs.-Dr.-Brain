using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevelOne ()
    {
        SceneManager.LoadScene("Level1");
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class QuitButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(QuitGame);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenButtons : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;


	// Use this for initialization
	void Start ()
    {
        startButton.onClick.AddListener(onStartClick);
        exitButton.onClick.AddListener(onExitClick);
    }

    void onStartClick()
    {
        SceneManager.LoadScene("scene1");
    }

    void onOptionsClick()
    {

    }

    void onExitClick()
    {
        Application.Quit();
    }
}

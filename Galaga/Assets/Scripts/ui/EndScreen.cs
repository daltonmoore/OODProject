
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Button menuButton;
    public Button exitButton;


    // Use this for initialization
    void Start()
    {
        menuButton.onClick.AddListener(onMenuClick);
        exitButton.onClick.AddListener(onExitClick);

    }

    void onMenuClick()
    {
        SceneManager.LoadScene("TitleScreen");
    }


    void onExitClick()
    {
        Application.Quit();
    }
}

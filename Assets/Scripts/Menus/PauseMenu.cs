using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu = null;

    [SerializeField]
    Button continueButton = null;

    [SerializeField]
    Button quitButton = null;

    [SerializeField]
    AudioSource pauseAudio = null;

    void OnEnable()
    {
        pauseAudio.Play();
        continueButton.onClick.AddListener (HandlerContinueSelected);
        quitButton.onClick.AddListener (HandlerQuitSelected);
    }

    void OnDisable()
    {
        continueButton.onClick.RemoveListener (HandlerContinueSelected);
        quitButton.onClick.RemoveListener (HandlerQuitSelected);
    }

    public void Show()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Hide()
    {
        pauseAudio.Play();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    void HandlerContinueSelected()
    {
        Hide();
    }

    void HandlerQuitSelected()
    {
        Debug.Log("Quitting");
        QuitGame();
    }

    void QuitGame()
    {
        Application.Quit();
    }
}

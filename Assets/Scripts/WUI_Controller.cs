using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WUI_Controller : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject helpPanel;
    public AudioClip song;


    public void HelpToMain()
    {
        // Disable help panel, re-enable main panel
        helpPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void Help()
    {
        // Disable main and enable help panels
        mainPanel.SetActive(false);
        helpPanel.SetActive(true);
    }
    public void LevelOne()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = song;
        audio.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
}

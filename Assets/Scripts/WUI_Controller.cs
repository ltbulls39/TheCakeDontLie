using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WUI_Controller : MonoBehaviour
{
    public void LevelOne()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }

}

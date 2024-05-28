using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject _menu; 


    private void Update()
    {
        OnPause();
    }

    public void ResumeBtn()
    {
        _menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }


    public void OnPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
}

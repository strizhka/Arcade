using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _tutorual;
    public void PlayBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }

    public void TutorialBtn()
    {
        Time.timeScale = 1;
        _tutorual.SetActive(true);
    }

    public void CloseBtn()
    {
        Time.timeScale = 1;
        _tutorual.SetActive(false);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}

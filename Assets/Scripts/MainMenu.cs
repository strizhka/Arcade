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
        _tutorual.SetActive(true);
    }

    public void CloseBtn()
    {
        _tutorual.SetActive(false);
    }

}

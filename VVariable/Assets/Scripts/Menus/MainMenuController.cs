using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    #region Refernces

    [Header("Buttons")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject HowToPlay;
    [SerializeField] private GameObject Title;

    #endregion

    #region Start

    private void Start()
        {
            Title.transform.DOScale(new Vector3(1, 1, 1), 3).Play().SetEase(Ease.Linear);
        }

    #endregion

    #region Buttons
    public void startGame()
    {
        PauseMenu.Pause = false;
        SceneManager.LoadScene(1);
    }
    public void OpenHowToPlay()
    {
        MainMenu.SetActive(false);
        HowToPlay.SetActive(true);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void Return()
    {
        HowToPlay.SetActive(false);
        MainMenu.SetActive(true);
    }

    #endregion

    #region HowToPlay
    public void HowToPlayPress()
    {
        HowToPlay.SetActive(enabled);
    }

    #endregion  

}
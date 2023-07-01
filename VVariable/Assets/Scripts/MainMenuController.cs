using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    #region Variables
    [Header("SerializedFields")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject HowToPlay;

    #endregion


    #region Buttons
    public void startGame()
    {
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
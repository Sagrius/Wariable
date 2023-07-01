using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    #region Variables

    [SerializeField] public GameObject deathPannel;
    [SerializeField] public GameObject[] hp;
    [SerializeField] public int currenthp;
    public static bool looped = false;

    #endregion

    #region Start

    void Start()
    {
        currenthp = 2;
    }

    #endregion

    #region Buttons
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        looped = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        looped = true;
    }

    #endregion

    #region Collider

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(hp[currenthp]);
            if (currenthp > 0)
            {
                currenthp--;
            }
            else
            {
                deathPannel.SetActive(true);
            }

        }
    }

    #endregion
}

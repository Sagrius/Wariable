using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class PlayerHP : MonoBehaviour
{
    #region References

    [Header("Death Panel")]
    [SerializeField] private GameObject Skull1;
    [SerializeField] private GameObject Skull2;
    public GameObject deathPannel;
    public TextMeshProUGUI text;
    
    [Header ("Sounds")]
    public AudioSource playerGotHitAS;
    public AudioClip playerGotHitSound;

    [Header ("Player HP")]
    public GameObject[] hp;
    public int currenthp;
   
    [Header ("HP Reseter")]
    public static bool looped = false;
    [Header("Player Position Reset")]
    public GameObject playerSprite;
    #endregion

    #region Start

    void Start()
    {
        currenthp = 2;
        Skull1.transform.DORotate(new Vector3(0, 0, -60), 2f, RotateMode.FastBeyond360).Play().SetLoops(-1, LoopType.Yoyo).Loops();
        Skull2.transform.DORotate(new Vector3(0, 0, -60), 2f, RotateMode.FastBeyond360).Play().SetLoops(-1, LoopType.Yoyo).Loops();
        text.transform.DOShakePosition(0.5f, 10, 5).Play().SetLoops(-1).Loops();
    }

    #endregion

    #region Buttons
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        PauseMenu.Pause = false;
        looped = true;
    }
    public void RestartGame()
    {
        PauseMenu.Pause = false;
        SceneManager.LoadScene(1);
        looped = true;
   
    }

    #endregion

    #region Respawn
    private void Update()
    {
        if (RewardedAdsButton.watchedAd==true && currenthp ==0)
        {
            RewardedAdsButton.watchedAd = false;
            foreach (GameObject heart in hp)
            {  
                heart.SetActive(true);
                currenthp = 2;
                playerSprite.transform.position = new Vector3(-5.94f, -3.8f, 0);
            }
        }
      
    }

    #endregion

    #region Collider

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerGotHitAS.PlayOneShot(playerGotHitSound);
            hp[currenthp].SetActive(false);
            if (currenthp > 0)
            {
                Handheld.Vibrate();
                currenthp--;
            }
            else
            {
                Handheld.Vibrate();
                deathPannel.SetActive(true);
                PauseMenu.Pause = true;

            }

        }
    }

    #endregion

}

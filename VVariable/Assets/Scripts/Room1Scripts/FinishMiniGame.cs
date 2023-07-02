using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishMiniGame : MonoBehaviour
{
    public static bool isMiniGameFiished = false;
    
    #region References

    [SerializeField] private GameObject theball;
    public GameObject gyroed;
    public GameObject trap;
    public GameObject Basketball;
    public GameObject guideArrows;

    #endregion

    #region Start

    void Start()
    {
        isMiniGameFiished = false;
    }

    #endregion

    #region OnCollision

    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Ball")
        {
            Input.gyro.enabled = false;
            Destroy(gyroed);
            Destroy(trap);
            Destroy(this.gameObject);
            Basketball.SetActive(true);
            isMiniGameFiished = true;
            theball.transform.DOScale(new Vector3(1, 1, 1), 1).Play();
            guideArrows.SetActive(true);
            
        }
    }

    #endregion
}

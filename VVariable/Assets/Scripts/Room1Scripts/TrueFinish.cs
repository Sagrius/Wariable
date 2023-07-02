using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueFinish : MonoBehaviour
{
    [Header ("References")]
    public GameObject dbd;
    public GameObject theBall;
    public GameObject basketBall;
    public GameObject guideArrows;
    public GameObject guideArrows1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            dbd.SetActive(false);
            Destroy(theBall);
            Destroy(basketBall);
            guideArrows.SetActive(false);
            guideArrows1.SetActive(true);
        }
    }
}

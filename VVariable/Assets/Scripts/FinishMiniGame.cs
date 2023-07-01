using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishMiniGame : MonoBehaviour
{
    [SerializeField] public GameObject gyroed;
    [SerializeField] public GameObject trap;
    [SerializeField] public GameObject Basketball;
    [SerializeField] public static bool isMiniGameFiished = false;
    [SerializeField] private GameObject theball;
    

    // Start is called before the first frame update
    void Start()
    {
        isMiniGameFiished = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
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
            
        }
    }
}

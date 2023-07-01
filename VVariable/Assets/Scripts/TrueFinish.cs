using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueFinish : MonoBehaviour
{

    [SerializeField] public GameObject dbd;
    [SerializeField] public GameObject theBall;
    [SerializeField] public GameObject basketBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Destroy(dbd);
            Destroy(theBall);
            Destroy(basketBall);

        }
    }
}

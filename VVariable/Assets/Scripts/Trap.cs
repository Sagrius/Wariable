using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trap : MonoBehaviour
{
    [SerializeField] public GameObject trapobject;
    [SerializeField] public GameObject theRoom;
    [SerializeField] public Vector3 gyroMeter;
    [SerializeField] public Rigidbody2D ballRB;


    void Start()
    {
        gyroMeter = Vector3.zero;

    }


    void Update()
    {
        
        

            if (Input.gyro.enabled == true)
            {

            
            if (PauseMenu.Pause == false)
            {
                gyroMeter.z = Input.gyro.rotationRateUnbiased.z;
                theRoom.transform.Rotate(gyroMeter);
                ballRB.constraints = RigidbodyConstraints2D.None;
                
            }
            else
            {
                ballRB.constraints = RigidbodyConstraints2D.FreezePosition;
            }
            }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("pipilkakiblat");
            trapobject.SetActive(true);
            Input.gyro.enabled = true;
        }
    }
    
}
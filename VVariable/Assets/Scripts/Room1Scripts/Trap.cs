using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trap : MonoBehaviour
{
    [Header("References")]
     public GameObject trapobject;
     public GameObject theRoom;
     public Vector3 gyroMeter;
     public Rigidbody2D ballRB;

#region Start & Update

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

    #endregion

#region OnTrigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("pipilkakiblat");
            trapobject.SetActive(true);
            Input.gyro.enabled = true;
        }
    }

    #endregion
}
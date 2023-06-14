using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Camera[] cameraManager;
    public static bool isOnDoor;
    public static bool isOnRoom4 = false;
    private int cameraIndex;
    // Start is called before the first frame update

    
    void Start()
    {
        foreach(Camera currentCamera in cameraManager)
        {
            currentCamera.enabled = false;
        }

        cameraIndex = 0;
        cameraManager[cameraIndex].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnDoor == true)
        {
            if (PlayerController.isLookingLeft == true)
            {
                cameraManager[cameraIndex].enabled = false;
                cameraIndex--;
                cameraManager[cameraIndex].enabled = true;
                isOnDoor = false;
            }
            if (PlayerController.isLookingLeft == false)
            {
                cameraManager[cameraIndex].enabled = false;
                cameraIndex++;
                cameraManager[cameraIndex].enabled = true;
                isOnDoor = false;
            }
            if (cameraIndex == 3)
            {
                isOnRoom4 = true;
            }
        }
    }
}

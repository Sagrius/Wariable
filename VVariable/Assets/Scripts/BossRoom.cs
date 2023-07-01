using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject boss;
    public GameObject door;
    public GameObject button;
    public GameObject trueBG;
    public Camera Bosscamera;
    public AudioSource mainBGM;

    private void Update()
    {
        if(CameraController.cameraToReturn==Bosscamera)
        {
            boss.SetActive(true);
            door.SetActive(true);
            trueBG.SetActive(false);
            button.SetActive(false);
            mainBGM.gameObject.SetActive(false);
        }
    }

}

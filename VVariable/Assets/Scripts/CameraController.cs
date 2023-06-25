using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    #region Variables Region

    [SerializeField] public Transform player;
    public Camera[] cameraManager;

    #endregion

    #region Camera Control
    private void CameraActor()
    {
        if (player.transform.position.x <= 11.6f)
        {
            cameraManager[0].enabled = true;
            cameraManager[1].enabled = false;
            cameraManager[2].enabled = false;
        }
        if (player.transform.position.x > 11.61f && player.transform.position.x < 34.25f)
        {
            cameraManager[0].enabled = false;
            cameraManager[1].enabled = true;
            cameraManager[2].enabled = false;
        }
        if (player.transform.position.x >= 34.26f)
        {
            cameraManager[0].enabled = false;
            cameraManager[1].enabled = false;
            cameraManager[2].enabled = true;
        }
    }
   
    void Update()
    {
        CameraActor();
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PulledShooting : MonoBehaviour
{
    
    #region Variables
    [Header ("SerializedFields")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileLeftSpawnPoint;
    [Header("Variables")]
    public static Vector3 touchPos;
    private List<GameObject> instantiatedProjectiles = new();
    private Touch[] touchArray;
    private bool canShoot;

    [Header(("SFX"))]
    public AudioClip ShootingSound;
    public AudioSource playerAudioSource;
    #endregion

    #region Start & Update
    private void Start()
    {
        canShoot = true;
        for (int i = 0; i < 3; i++)
        {
            var instatiatedProjectile = Instantiate(projectilePrefab, transform);
            instatiatedProjectile.SetActive(false);
            instantiatedProjectiles.Add(instatiatedProjectile);
        }
    }

    void Update()
    {
        if (PauseMenu.Pause == false)
        {
            if (Input.touchCount > 0)
            {
                touchArray = new Touch[Input.touchCount];

                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    touchArray[i] = touch;

                    if (touchArray[i].phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        if (canShoot == true)
                        {
                            touchPos = CameraController.cameraToReturn.ScreenToWorldPoint(touch.position);
                            StartCoroutine(AbleToSpawn());
                            Debug.Log("TouchPos: " + touchPos);
                        }
                    }
                    else
                    {
                        if(touchArray[i].phase==TouchPhase.Moved)
                        {
                            Debug.Log("Moved");
                        }
                        if (touchArray[i].phase == TouchPhase.Ended)
                        {
                            Debug.Log("Ended");
                        }
                    }

                }
            }
        }
    }

    #endregion

    #region Object Pulling 
    GameObject GetObjectFromPool()
    {
        foreach (var projectile in instantiatedProjectiles)
        {
            if (!projectile.gameObject.activeSelf)
                return projectile;
        }
        Debug.LogWarning("No object to pool! we need more objects. Must construct additional objects");
        return null;
    }

    IEnumerator AbleToSpawn()
    {
        canShoot = false;
        var projectileToPull = GetObjectFromPool();
        if (projectileToPull != null)
        {
            projectileToPull.gameObject.SetActive(true);
            playerAudioSource.PlayOneShot(ShootingSound);

            projectileToPull.transform.position = projectileLeftSpawnPoint.position;
        }

        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
    #endregion

    #region PullTouchPosition
    public static Vector3 GiveTouchPos()
    {
        return touchPos;
    }
    #endregion

}
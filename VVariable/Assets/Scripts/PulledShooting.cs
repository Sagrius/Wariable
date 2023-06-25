using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulledShooting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    public Transform endPoint;
    private List<GameObject> instantiatedProjectiles = new List<GameObject>();

    private ResourceRequest _resourceRequest;

    private void Start()
    {
        
        for (int i = 0; i < 10; i++)
        {
            var instadProjectile = Instantiate(projectilePrefab, transform);
            instadProjectile.gameObject.SetActive(false);
            instantiatedProjectiles.Add(instadProjectile);
        }

    }


    // Update is called once per frame
    void Update()
    {

        if(Input.touchCount>= 1)
        {
            Debug.Log("touched");
            Touch touch = Input.GetTouch(0);
            Debug.Log($"{touch.position.x},{touch.position.y}");
            endPoint.position = touch.position;
            if (touch.phase == TouchPhase.Began)
            {
                var projectileToPull = GetObjectFromPool();
                if (projectileToPull != null)
                {
                    projectileToPull.gameObject.SetActive(true);
                    Transform projectileTransform = projectileToPull.transform;
                    projectileTransform.position = projectileSpawnPoint.position;
                    projectileTransform.rotation = projectileSpawnPoint.rotation;
                }
            }
        }

    }


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

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    #region Variables
    [SerializeField] public SpriteRenderer enemyrenderer;
    [SerializeField] public Sprite[] possibleHp;
    [SerializeField] public int currentHp;
    [SerializeField] public GameObject enemyBulletPrefab;
    [SerializeField] public Transform theKane;
    [SerializeField] public List<GameObject> bulletList;
    private bool canShoot;

    #endregion

    #region Start
    void Start()
    {
        canShoot = true;
        for (int  i = 0;  i <2;  i++)
        {
            var instatiatedProjectile = Instantiate(enemyBulletPrefab, transform);
            instatiatedProjectile.SetActive(false);
            bulletList.Add(instatiatedProjectile);
        }

        for (int i = 0; i < possibleHp.Length; i++)
        {
            if (enemyrenderer.sprite == possibleHp[i])
            {
                currentHp = i;
            }
        }
       


    }

    #endregion

    #region EnemyMovement

    private void Update()
    {
        if(canShoot ==true)
        {
           StartCoroutine(PlaceBullet());
        }
    }

    #endregion

    #region Trigger
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Bullet")
        {           
            if (currentHp > 1)
            {              
                Debug.Log(currentHp);
                currentHp--;
                enemyrenderer.sprite = possibleHp[currentHp];
            }
            else
            {
                
                Destroy(gameObject);
                EnemySpawner.enemiesCounter--;
            }
        }
    }
    #endregion

    IEnumerator PlaceBullet()
    {
        canShoot = false;
        var projectileToPull = BullletPlacer();
        yield return new WaitForSeconds(3f);
        if (projectileToPull != null && !PauseMenu.Pause)
        {
            projectileToPull.SetActive(true);
            projectileToPull.transform.position = theKane.position;    
        }
        
        canShoot = true;
    }
  public  GameObject BullletPlacer()
    {
        foreach (var projectile in bulletList)
        {
            if (!projectile.gameObject.activeSelf)
                return projectile;
        }
        Debug.LogWarning("No object to pool! we need more objects. Must construct additional objects");
        return null;
    }
}

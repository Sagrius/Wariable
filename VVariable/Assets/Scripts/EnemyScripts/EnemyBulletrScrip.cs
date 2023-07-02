using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletrScrip : MonoBehaviour
{
    #region Variables

    public float bulletSpeed;

    #endregion

    #region Update
    void Update()
    {
        GetShooted();
    }

    #endregion

    #region Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    }

    #endregion

    #region BulletProjection
    public void GetShooted()
    {
        if (PauseMenu.Pause ==false)
        {
            var playerLocation = EnemySpawner.playerLocation;
            transform.position = Vector3.MoveTowards(transform.position, playerLocation, bulletSpeed*Time.deltaTime);
        }
    }

    #endregion
}

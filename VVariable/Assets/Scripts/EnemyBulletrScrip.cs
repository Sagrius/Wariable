using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBulletrScrip : MonoBehaviour
{
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetShooted();
    }
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

    public void GetShooted()
    {
        if (PauseMenu.Pause ==false)
        {
            var playerLocation = EnemySpawner.playerLocation;
            Debug.Log($"{playerLocation.x}, {playerLocation.y}, {playerLocation.z}");
            transform.position = Vector3.MoveTowards(transform.position, playerLocation, bulletSpeed*Time.deltaTime);
        }
       
      
    }
}

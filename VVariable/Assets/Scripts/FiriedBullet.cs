using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FiriedBullet : MonoBehaviour
{
    #region Variables
    [SerializeField] private float bulletSpeed;
    private Vector3 whereToGo;
    #endregion

    #region Trigger 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {

            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Ground")
        {

            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Enemy")
        {

            gameObject.SetActive(false);
        }

    }
    #endregion

    #region Update
    void FixedUpdate()
    {
        BulletMoveTo();
        
        //Destroy Bullet on target position
        if (transform.position == whereToGo)
        {
            gameObject.SetActive(false);
        }

    }
    #endregion

    #region WhereToGo
    public Vector3 GetScript()
    {
        return PulledShooting.GiveTouchPos();
    }
    private void BulletMoveTo()
    {
        whereToGo = GetScript();
        transform.position = Vector3.MoveTowards(transform.position , whereToGo, bulletSpeed * Time.deltaTime);
    }

    #endregion
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FiriedBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform endPoint;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(endPoint.position, 10f).OnComplete(GoingDown);
    }

    public void GoingDown()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

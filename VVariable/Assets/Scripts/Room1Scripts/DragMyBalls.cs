using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMyBalls : MonoBehaviour
{
    [Header ("The ball")]
    public Rigidbody2D ball;

    private void OnMouseDrag()
    {

        if (FinishMiniGame.isMiniGameFiished == true)
        {
            if (PauseMenu.Pause == false)
            {
                if (Input.touchCount > 0)
                {
                    ball.constraints = RigidbodyConstraints2D.None;
                    Touch touch = Input.GetTouch(0);
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0f;
                    ball.MovePosition(touchPosition);
                }          
            }
            else
            {
                ball.constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
    }

}

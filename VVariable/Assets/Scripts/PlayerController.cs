using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    #region Variables Region

    [SerializeField] private Rigidbody2D body;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _pushPower;
    private bool onGround;
    private int jumpCounter = 0;

    #endregion

    #region Collider Checker

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }

    }

    #endregion

    #region Dash and Jump
    public void Dash()
    {
        //Check if Joystick on left side and push left
        if (joystick.Horizontal < 0)
            body.AddForce(Vector2.left * _pushPower, ForceMode2D.Force);
        //Check if Joystick on right side and push right
        if (joystick.Horizontal >= 0)
            body.AddForce(Vector2.right * _pushPower, ForceMode2D.Force);

    }
    public void Jump()
    {
        //Check if player is on ground and set max jump times to 2
        if (onGround == true && jumpCounter < 2)
        {
            //jump and up counter
            body.AddForce(Vector2.up * _jumpPower, ForceMode2D.Force);
            jumpCounter++;

        }
        //double jump reset
        if (jumpCounter == 2)
        {
            onGround = false;
            jumpCounter = 0;
        }
    }

    #endregion

    #region L/R Movement

    private void FixedUpdate()
    {

        body.velocity = new Vector2(joystick.Horizontal * _moveSpeed, 0);
    }

    #endregion

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Data;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    #region Variables Region

    [SerializeField] public Rigidbody2D body;
    [SerializeField] private TrailRenderer TR;
    

    [Header ("Movement")]
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float _moveSpeed;

    [Header("Jump")]
    private int jumpCounter = 0;
    private bool onGround;

    [Header("Dash")]
    [SerializeField] private float dashingPower = 150f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;
    private bool canDash = true;
    private bool isDashing;
    private bool isButtonPressed = false;



    #endregion

    #region Collider Checker

 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {          
            onGround = true;
           
        }

    }

    public void JumpButtonPressed()
    { 
        isButtonPressed = true; 
    }
    #endregion

    #region Dash and Jump
    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        if (joystick.Horizontal < 0)
        { 
            body.velocity = Vector2.left * dashingPower;
        }
        if (joystick.Horizontal >= 0)
        {
            body.velocity = Vector2.right * dashingPower ;
        }
        TR.emitting = true;
        yield return new WaitForSeconds(dashingCooldown);
        TR.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        isButtonPressed = false;

    }

    void TRoff()
    {
        TR.emitting = false;
    }
    public void Jump()
    {

        
        //Check if player is on ground and set max jump times to 2
        if (onGround == true && jumpCounter < 2)
        {
            TR.emitting = true;
            body.DOJump(body.position, 2, 1, 0.6f).SetEase(Ease.Linear).OnComplete(TRoff);
            //TR.emitting = false;
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

        if(isButtonPressed == true && canDash == true)
        { 
        StartCoroutine(Dash());
        }

    }
 

    #endregion

}
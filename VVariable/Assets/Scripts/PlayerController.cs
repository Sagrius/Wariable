using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    #region Variables Region

    [SerializeField] public Rigidbody2D body;
    [SerializeField] private TrailRenderer TR;
    

    [Header ("Movement")]
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float _moveSpeed;

    [Header("Jump")]
    [SerializeField] private float jumpPower;
    private int jumpCounter = 0;
    private bool onGround;
    private bool jumpButtonPressed = false;
    public Transform rotation;

    [Header("Dash")]
    [SerializeField] private float dashingPower = 150f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;
    private bool canDash = true;
    private bool isDashing;
    private bool dashButtonPressed = false;


    [Header("SFX")]
    public AudioSource playerAudioSource;
    public AudioClip jumpSound;
    public AudioClip dashSound;

    #endregion

    #region Updates
    private void Update()
    {
        if (PauseMenu.Pause == false)
        {
            body.constraints = RigidbodyConstraints2D.None;
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            body.constraints = RigidbodyConstraints2D.FreezePosition;
            body.AddForce(Vector2.down * body.gravityScale);
            body.SetRotation(0f);
        }
    }
    void FixedUpdate()
    {
        if (PauseMenu.Pause == false)
        {
            
            Movement();

            if (dashButtonPressed == true && canDash == true /*&*//* PauseMenu.Pause == false*/)
            {
                StartCoroutine(Dash());
            }
            if (jumpButtonPressed == true /*& PauseMenu.Pause==false*/)
            {
                Jump();
            }
        }
       
    }
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

    #region Dash
    public void dashButtonPress()
    {
        dashButtonPressed = true;
    }
   
    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        playerAudioSource.PlayOneShot(dashSound);
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
        dashButtonPressed = false;

    }

    #endregion

    #region Jump
    public void Jump()
    {
        //Check if player is on ground and set max jump times to 2
        if (onGround == true && jumpCounter < 2)
        {
            playerAudioSource.PlayOneShot(jumpSound);
            body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCounter++;
                
        }
        //double jump reset
        if (jumpCounter == 2)
        {
            onGround = false;
            jumpCounter = 0;
        }
        
        jumpButtonPressed = false;
    }
    public void jumpButtonPress()
    {
        jumpButtonPressed = true;        
    }
#endregion

    #region L/R Movement

    private void Movement()
    {
        body.velocity = new Vector2(joystick.Horizontal * _moveSpeed, 0);

    }
   
   

    #endregion

}
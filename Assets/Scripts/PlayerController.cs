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
    [SerializeField] private GameObject Door123;
    [SerializeField] private GameObject Door456;
    

    [Header ("Movement")]
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float _moveSpeed;

    [Header("Jump")]
    [SerializeField] private float _jumpPower;
    private int jumpCounter = 0;
    private bool onGround;

    [Header("Dash")]
    [SerializeField] private float dashingPower = 150f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;
    private bool canDash = true;
    private bool isDashing;
    private bool isButtonPressed = false;

    [Header("Camera Bool")]
    public static bool isLookingLeft = false;
    float timer = 2f;

    #endregion

    #region Collider Checker

 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {          
            onGround = true;
            
        }

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door Left")
        {

            CameraController.isOnDoor = true;

            isLookingLeft = true;
            body.transform.DOMoveX(transform.position.x - 3, 1f);
            collision.gameObject.SetActive(false);
            Invoke("reactivate2", 2f);
            //Door456.gameObject.SetActive(true);

        }
        if (collision.gameObject.tag == "Door Right")
        {

            CameraController.isOnDoor = true;
        
                isLookingLeft = false;
                body.transform.DOMoveX(transform.position.x + 3, 1f);
            collision.gameObject.SetActive(false);
            Invoke("reactivate1",2f);
            //Door123.gameObject.SetActive(true);




        }
    }
       public void reactivate1()
    { Door123.gameObject.SetActive(true); }
    public void reactivate2()
    { Door456.gameObject.SetActive(true); }

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
    public void buttonDownCheck()
    {
        isButtonPressed = true;
    }

    public void Jump()
    {

        
        //Check if player is on ground and set max jump times to 2
        if (onGround == true && jumpCounter < 2)
        {           
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
    void leTimer()
    {

            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0)
            { 
                        timer = 2;
                     CameraController.isOnDoor = false;
            }
       
    }
    #region L/R Movement

    private void FixedUpdate()
    {
        if(CameraController.isOnDoor == true)
        leTimer();
        


        if (joystick.Horizontal < 0)
        {
            isLookingLeft = true;
        }
        if (joystick.Horizontal >= 0)
        {
            isLookingLeft = false;
        }
        body.velocity = new Vector2(joystick.Horizontal * _moveSpeed, 0);

        if(isButtonPressed == true && canDash == true)
        { 
        StartCoroutine(Dash());
        }

    }
 

    #endregion

}
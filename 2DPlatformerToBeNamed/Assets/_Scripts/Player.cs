using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    //Touch Control Stuff
    //private bool isMovingLeft, isMovingRight, startedJumping, Jumping, afterJumping;

    //Anim Controller Stuff
    public static bool lastJumpBoolISwear;
    public static float xAxisInput;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        //print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
    }

    /////////////////////////////////TOUCH CONTROL STUFF/////////////////////////////
    /*
    public void SetMovingLeft(bool value)
    {
        isMovingLeft = value;
    }

    public void SetMovingRight(bool value)
    {
        isMovingRight = value;
    }

    public void SetJumpingOn()
    {
        if(!Jumping && !startedJumping)
        {
            afterJumping = false;
            startedJumping = true;
            Jumping = true;
        }
    }

    public void SetJumpingOff()
    {
        if(Jumping)
        {
            Jumping = false;
            afterJumping = true;
        }
    }
    */

    void Update()
    {
        if (Controller2D.collisions.above || Controller2D.collisions.below)
        {
            velocity.y = 0;
        }

        //////////////////////////TOUCH CONTROL STUFF///////////////////////////////////
        /*
        if ((isMovingLeft && isMovingRight) || (!isMovingLeft && !isMovingRight))
        {
            xAxisInput = 0;
        }
        else if (isMovingLeft)
        {
            xAxisInput = -1f;
        }
        else
        {
            xAxisInput = 1f;
        }

        if ((startedJumping && Controller2D.collisions.below))
        {

            velocity.y = maxJumpVelocity;
            startedJumping = false;
            lastJumpBoolISwear = true;  //only needed for animation controller         
        }

        if (!Jumping && afterJumping)
        {

            if (velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;

            }
            afterJumping = false;
            lastJumpBoolISwear = false;   //only needed for animation controller
        }
        Vector2 input = new Vector2(xAxisInput, 0);
        */

        //////////////////////////////////////KEYBOARD AND MOUSE INPUT STUFF//////////////////////////////////////////
        
        if (Input.GetKeyDown(KeyCode.Space) && Controller2D.collisions.below)
        {
            velocity.y = maxJumpVelocity;
            lastJumpBoolISwear = true;//only for anim controller
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            lastJumpBoolISwear = false;//only for anim controller
            if (velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;
            }
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        xAxisInput = input.x; //only for anim controller





        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (Controller2D.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

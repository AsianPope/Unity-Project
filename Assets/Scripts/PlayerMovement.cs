using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rd;

    bool moveLeft;
    bool moveRight;
    bool moveForward;
    bool moveBackward;
    float horizontalMove;
    float verticalMove;
    public float speed = 300;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // left button
    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    //right button
    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    //forward button
    public void PointerDownForward()
    {
        moveForward = true;
    }

    public void PointerUpForward()
    {
        moveForward = false;
    }

    //backward button
    public void PointerDownBackward()
    {
        moveBackward = true;
    }

    public void PointerUpBackward()
    {
        moveBackward = false;
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }

        if (moveForward)
        {
            verticalMove = speed;
        }
        else if (moveBackward)
        {
            verticalMove = -speed;
        }
        else
        {
            verticalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        rd.velocity = new Vector3(horizontalMove * Time.deltaTime, rd.velocity.y, verticalMove * Time.deltaTime);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    public float speed = 5.0f;
    //Screen limits
    private float xMin, xMax, yMin, yMax;
    //Speed of the object
    public Vector3 direction = Vector3.zero;
    void Update()
    {
        limits();
        checking();
        move();
    }

    //Defines the limits of the screen
    void limits()
    {
        Camera gameCamera = Camera.main;
        float distanceToCamera = Mathf.Abs(transform.position.z - gameCamera.transform.position.z);
        xMax = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, distanceToCamera)).x - transform.localScale.x / 2;
        xMin = gameCamera.ScreenToWorldPoint(new Vector3(0, 0, distanceToCamera)).x + transform.localScale.x / 2;
        yMax = gameCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, distanceToCamera)).y - transform.localScale.y / 2;
        yMin = gameCamera.ScreenToWorldPoint(new Vector3(0, 0, distanceToCamera)).y + transform.localScale.y / 2;
    }
    //When the object enters the screen, it changes direction
    void checking()
    {

        if (transform.position.x > xMax)
        {
            direction = Vector3.back;
        }
        else if (transform.position.x < xMin)
        {
            direction = Vector3.forward;
        }
        else if (transform.position.y > yMax)
        {
            direction = Vector3.down;
        }
        else if (transform.position.y < yMin)
        {
            direction = Vector3.up;
        }
    }
    //Responsible for moving the object
    void move()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

}

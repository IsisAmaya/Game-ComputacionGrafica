using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;


public class BounceMovement : MonoBehaviour
{
    //Speed of the object
    public float speed = 2.5f;
    //Screen limits
    private float xMin, xMax, yMin, yMax;
    //Direction of the object
    public Vector3 direction = Vector3.zero;



    void Update()
    {
        SetMovementBounds();
        CheckBoundaryCollision();
        Move();
    }
    //sets the screen limits
    void SetMovementBounds()
    {
        Camera gameCamera = Camera.main;
        float distanceToCamera = Mathf.Abs(transform.position.z - gameCamera.transform.position.z);
        xMax = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, distanceToCamera)).x;
        xMin = gameCamera.ScreenToWorldPoint(new Vector3(0, 0, distanceToCamera)).x;
        yMax = gameCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, distanceToCamera)).y;
        yMin = gameCamera.ScreenToWorldPoint(new Vector3(0, 0, distanceToCamera)).y;
    }
    //responsable for moving the object
    void Move()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    //When the object enters the screen, it changes direction
    void CheckBoundaryCollision()
    {

        if (transform.position.x > xMax)
        {
            // Si la posición en x supera el límite máximo, ajusta la posición a xMax
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
            direction = new Vector3(-direction.x, direction.y, -direction.z);
        }
        else if (transform.position.x < xMin)
        {
            // Si la posición en x es menor que el límite mínimo, ajusta la posición a xMin
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
            direction = new Vector3(-direction.x, direction.y, -direction.z);
        }
        // Si la posición en y supera el límite máximo, ajusta la posición a yMax
        if (transform.position.y > yMax && direction.y > 0)
        {
            //Invirtiendo la dirección en y
            direction = new Vector3(direction.x, -direction.y, direction.z);
        }
        else if (transform.position.y < yMin && direction.y < 0)
        {
            direction = new Vector3(direction.x, -direction.y, direction.z);
        }

    }
}



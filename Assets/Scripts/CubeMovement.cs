using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public GameObject Canva;
    public float speed = 5.0f;
    public float timeStart = 20;
    private float xMin;
    private float xMax;
    Vector3 direction = Vector3.zero;
    void Start()
    {
        UIManager timer  = Canva.GetComponent<UIManager>();
        timeStart =  20;

        Invoke("timer", timeStart);
        
        timer.getTime(timeStart);

    }
    void Update()
    {
        checking();
        transform.Translate(direction * Time.deltaTime * speed);
    }

    void timer()
    {
        Destroy(gameObject);
    }

    void checking()
    {
        Camera gameCamera = Camera.main;
        float distanceToCamera = Mathf.Abs(transform.position.z - gameCamera.transform.position.z);
        xMax = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, distanceToCamera)).x;
        xMin = gameCamera.ScreenToWorldPoint(new Vector3(0, 0, distanceToCamera)).x;


        if (transform.position.x > xMax)
        {
            direction = Vector3.back;
        }
        if (transform.position.x < xMin)
        {
            direction = Vector3.forward;
        }
    }
}

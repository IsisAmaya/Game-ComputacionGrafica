using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class MousePosition : MonoBehaviour
{
    public GameObject player;
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    public float shootCooldown = 1f; // Tiempo de reutilización en segundos
    private float nextShootTime = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        screenPosition = Input.mousePosition;

        Ray ray= Camera.main.ScreenPointToRay(screenPosition);

        transform.position = worldPosition;  

        shoot(ray);
    }

    private void shoot(Ray ray)
    {
        if (Time.time < nextShootTime){
            return; 
        }

        if (Input.GetMouseButtonDown(0)) {
            nextShootTime = Time.time + shootCooldown; 
            Debug.Log(nextShootTime);


            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                HitBoxCube hitBoxCube = objectHit.GetComponent<HitBoxCube>();
                Player score  = player.GetComponent<Player>();
                if (hitBoxCube != null)
                {
                    hitBoxCube.golpe();
                    score.addScore(1);
                }
            }            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class MousePosition : MonoBehaviour
{
    public GameObject player;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    // Start is called before the first frame update
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
        RaycastHit hit;
        
        // Dibujar el rayo para depuración
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);
        
        if (Input.GetMouseButtonDown(0)) {
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

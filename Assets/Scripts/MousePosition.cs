using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class MousePosition : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position();
        hor();
    }

    void position()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objectPos;

    }

    void hor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
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

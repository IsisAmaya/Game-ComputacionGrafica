using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MousePosition : MonoBehaviour
{
    public GameObject player;
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    public bool powerup = false;
    public float shootCooldown = 1f; // Tiempo de reutilización en segundos
    private float nextShootTime = 0f;
    public AudioClip cooldownActiveSound;
    public AudioClip shootReadySound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        transform.position = worldPosition;
        shoot(ray);
    }

    private void shoot(Ray ray)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextShootTime)
            {
                nextShootTime = Time.time + shootCooldown;
                audioSource.PlayOneShot(shootReadySound);
                Debug.Log(nextShootTime);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    HitBoxCube hitBoxCube = objectHit.GetComponent<HitBoxCube>();
                    ItemHitBox itemHitBox = objectHit.GetComponent<ItemHitBox>();
                    Player score = player.GetComponent<Player>();
                    if (hitBoxCube != null)
                    {
                        hitBoxCube.golpe();
                        score.addScore(1);
                    }

                    if (itemHitBox != null)
                    {
                        itemHitBox.powerup();
                    }
                }
            }

            else {
                audioSource.PlayOneShot(cooldownActiveSound);
            }
        }
    }
}

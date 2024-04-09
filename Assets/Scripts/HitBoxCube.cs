using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HitBoxCube : MonoBehaviour
{
    public Material hit;
    public Material nohit;
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void golpe()
    {
        Destroy(gameObject);
        //meshRenderer.material = hit;
    }


}

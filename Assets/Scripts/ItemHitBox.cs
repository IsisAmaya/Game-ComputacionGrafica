using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class ItemHitBox : MonoBehaviour
{

    //Power up que disminuye el tiempo de reutilización del disparo a 0.0f durante 5 segundos
    //Power up que disminuye el tiempo de reutilización del disparo a 0.0f durante 5 segundos
    public void powerup()
    {
        // Obtener una referencia al componente MousePosition
        // Obtener la cámara principal de la escena
        Camera mainCamera = Camera.main;

        // Obtener el componente MousePosition de la cámara
        MousePosition mousePosition = mainCamera.GetComponent<MousePosition>();

        // Verificar si se encontró el componente MousePosition
        if (mousePosition != null)
        {
            // Modificar la variable shootCooldown del componente MousePosition
            mousePosition.shootCooldown = 0.0f;

            // Esperar durante 5 segundos
            StartCoroutine(ResetShootCooldownAfterDelay(mousePosition));
        }
        else
        {
            Debug.LogWarning("MousePosition component not found.");
        }

        // Destruir el objeto actual
        Destroy(gameObject);
    }

    private IEnumerator ResetShootCooldownAfterDelay(MousePosition mousePosition)
    {
        // Esperar 5 segundos
        yield return new WaitForSeconds(5.0f);

        // Restaurar el valor original de shootCooldown
        mousePosition.shootCooldown = 1.0f;
    }
}
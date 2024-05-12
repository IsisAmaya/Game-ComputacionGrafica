using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTexture1;
    public Texture2D cursorTexture2;
    
    void Start()
    {
        SetCursor();
    }

    void SetCursor()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (sceneName == "DuckSeason")
        {
            Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
        }
        else if (sceneName == "MainMenu" || sceneName == "GameOver")
        {
            Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
        }
    }
}

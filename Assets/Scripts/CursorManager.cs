using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        string[] levels = {"DuckSeason", "Level-1", "Level-2", "Level-3", "Level-4", "Level-5"};
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (System.Array.Exists(levels, element => element == sceneName))
        {
            Cursor.SetCursor(cursorTexture1, Vector2.zero, CursorMode.Auto);
        }
        else if (sceneName == "MainMenu" || sceneName == "GameOver")
        {
            Cursor.SetCursor(cursorTexture2, Vector2.zero, CursorMode.Auto);
        }
    }
}

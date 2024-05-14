using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public void StartButton() {
        SceneManager.LoadScene("Level-1");
    }

    public void LevelsButton() {
        SceneManager.LoadScene("Levels");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;  // Tambahkan ini untuk mengakses EditorApplication

public class KelolaScene : MonoBehaviour
{
    public string EnterScene;
    public string EscapeScene;
    public bool isEscapeForQuit = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Pengecekan tombol Enter untuk load scene
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Name Scene: " + EnterScene);
            SceneManager.LoadScene(EnterScene);
        }

        // Pengecekan tombol Escape
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeForQuit)
            {
                Debug.Log("Escape pressed, quitting the game...");
                // Menambahkan pengecekan untuk Application.Quit() pada editor
                if (Application.isEditor)
                {
                    Debug.Log("Stopping play mode in Editor...");
                    EditorApplication.isPlaying = false;  // Berhenti dari mode Play di Editor
                }
                else
                {
                    Application.Quit();
                }
            }
            else
            {
                Debug.Log("Name Scene: " + EscapeScene);
                SceneManager.LoadScene(EscapeScene);
            }
        }
    }
}

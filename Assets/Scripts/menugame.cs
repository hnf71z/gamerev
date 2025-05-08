using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menugame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void PlayGame(string scenename)
    {
        Debug.Log("Tombol play ditekan. Akan pindah ke scene: " + scenename);
Audio.instance.GetComponent<Audio>().musicSource.Stop();

        SceneManager.LoadScene(scenename);
    }

    public void MainMenu(string scenename)
    {
Audio.instance.GetComponent<Audio>().musicSource.Stop();

    Debug.Log("Tombol back ditekan. Akan pindah ke scene: " + scenename);
    SceneManager.LoadScene(scenename);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject creditpanel;
    public GameObject[] profilePanels; // array panel profil
    private int currentIndex = 0;

    public void ShowNextProfile() {
        // Sembunyikan panel profil saat ini
        profilePanels[currentIndex].SetActive(false);

        // Geser ke index berikutnya
        currentIndex++;
        if (currentIndex >= profilePanels.Length) {
            currentIndex = 0; // Kembali ke profil pertama
        }
        // Tampilkan panel profil berikutnya
        profilePanels[currentIndex].SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Jumlah panel: " + profilePanels.Length);
        menupanel.SetActive(true);
        creditpanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void ShowCredits()
    {
        menupanel.SetActive(false);
        creditpanel.SetActive(true);
    }

    public void ShowMenu()
    {
        menupanel.SetActive(true);
        creditpanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


}

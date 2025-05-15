using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomainmenu : MonoBehaviour
{
    // Ganti "MainMenu" dengan nama scene Anda untuk menu utama
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

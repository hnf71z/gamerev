using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Fungsi ini dipanggil ketika tombol "Kembali Ke Main Menu" ditekan
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("mainmenu");  // Ganti "MainMenu" dengan nama scene Main Menu kamu
    }

    // Fungsi ini dipanggil ketika tombol "Ulangi Permainan" ditekan
    public void RestartGame()
    {
        SceneManager.LoadScene("hockeyAI");  // Ganti "GameScene" dengan nama scene permainan kamu
    }
}

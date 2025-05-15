using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnUlangi : MonoBehaviour
{
    public void ReloadGame()
    {
        // Muat ulang scene aktif (permainan saat ini)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

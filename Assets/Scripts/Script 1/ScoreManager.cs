using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // supaya tidak hilang saat ganti scene
        }
        else
        {
            Destroy(gameObject); // jika duplikat, hapus
        }
    }

    public void AddPoints(int points)
    {
        score += points;
    }

    public void ResetPoints()
    {
        score = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    public AudioSource musicSource;
    public AudioClip musicClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Menjaga objek ini agar tidak dihancurkan saat pindah scene
        }
        else
        {
            Destroy(gameObject); // Menghancurkan objek ini jika sudah ada instance lain
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

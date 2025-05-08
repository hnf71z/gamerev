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
        // Menghancurkan objek ini jika sudah ada objek lain dengan nama yang sama
        // DontDestroyOnLoad(gameObject);
        // if (musicSource == null)
        // {
        //     musicSource = GetComponent<AudioSource>();
        // } 

        // if (musicSource != null && musicClip != null)
        // {
        //     musicSource.clip = musicClip;
        //     musicSource.loop = true; // Mengatur agar musik diputar berulang
        //     musicSource.Play(); // Memulai pemutaran musik
        // }
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

using UnityEngine;

public class DragDropTrigger : MonoBehaviour
{
    public string nameTag;
    public AudioClip audioBenar;
    public AudioClip audioSalah;
    private AudioSource MediaPlayerBenar;
    private AudioSource MediaPlayerSalah;

    private bool triggerAktif = false;

    void Start()
    {
        MediaPlayerBenar = gameObject.AddComponent<AudioSource>();
        MediaPlayerBenar.clip = audioBenar;
        MediaPlayerBenar.playOnAwake = false;

        MediaPlayerSalah = gameObject.AddComponent<AudioSource>();
        MediaPlayerSalah.clip = audioSalah;
        MediaPlayerSalah.playOnAwake = false;

        // Aktifkan trigger setelah delay supaya tidak langsung memicu OnTriggerEnter
        Invoke("AktifkanTrigger", 1f); // tunda 1 detik
    }

    void AktifkanTrigger()
    {
        triggerAktif = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggerAktif) return;

        if (collision.CompareTag(nameTag))
        {
            collision.transform.position = transform.position;
            MediaPlayerBenar.Play();
        }
        else
        {
            MediaPlayerSalah.Play();
        }
    }
}

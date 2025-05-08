using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakProfesi : MonoBehaviour
{
    // Posisi target untuk pergerakan di sumbu X
    int[] posX = new int[] {0, -30, -60, -90, -120, -150, -180, -210};
    int idx = 0;

    // Array audio source, diganti nama untuk hindari konflik dengan bawaan Unity
    public AudioSource[] suaraProfesi;

    void Start()
    {
        // Pastikan tidak null sebelum play
        if (suaraProfesi != null && suaraProfesi.Length > 0 && suaraProfesi[idx] != null)
        {
            suaraProfesi[idx].Play();
        }
    }

    void Update()
    {
        // Tombol ke kanan
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (idx < posX.Length - 1)
            {
                if (suaraProfesi != null && suaraProfesi[idx] != null)
                    suaraProfesi[idx].Stop();

                idx++;

                if (suaraProfesi != null && suaraProfesi[idx] != null)
                    suaraProfesi[idx].Play();
            }
        }

        // Tombol ke kiri
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (idx > 0)
            {
                if (suaraProfesi != null && suaraProfesi[idx] != null)
                    suaraProfesi[idx].Stop();

                idx--;

                if (suaraProfesi != null && suaraProfesi[idx] != null)
                    suaraProfesi[idx].Play();
            }
        }

        // Gerakkan objek ke posisi target
        Vector3 targetPos = new Vector3(posX[idx], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 50 * Time.deltaTime);
    }
}

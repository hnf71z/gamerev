using UnityEngine;

public class DropTarget : MonoBehaviour
{
    [Header("Tag yang Diterima")]
    public string acceptTag; // Harus sama dengan correctDropTag dari objek drag

    public void OnCorrectDrop()
    {
        // Tambahkan efek atau aksi tambahan jika drop benar (opsional)
        Debug.Log("✔️ Objek dijatuhkan di tempat yang tepat");
    }
}

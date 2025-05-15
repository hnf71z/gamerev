using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_drag : MonoBehaviour
{
    private Vector3 savePosisi;
    public bool IsDiAtasObj;
    private Transform dropTarget; // ⬅️ Tambahan untuk menyimpan posisi drop zone

    void Start()
    {
        savePosisi = transform.position;
    }

    private void OnMouseUp()
    {
        if (IsDiAtasObj && dropTarget != null)
        {
            // Snap ke posisi tengah drop zone
            transform.position = dropTarget.position;
        }
        else
        {
            // Balik ke posisi semula
            transform.position = savePosisi;
        }
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPos;
    }

    private void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("drop"))
        {
            IsDiAtasObj = true;
            dropTarget = trig.transform; // ⬅️ Simpan referensi ke area drop
        }
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("drop"))
        {
            IsDiAtasObj = false;
            dropTarget = null;
        }
    }
}

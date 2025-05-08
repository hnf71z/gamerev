using UnityEngine;
using UnityEngine.EventSystems;

public class DropZoneHandler : MonoBehaviour, IDropHandler
{
    public string acceptedTag; // tag profesi yang sesuai drop zone

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped != null)
        {
            DragHandler drag = dropped.GetComponent<DragHandler>();

            // Cek apakah tag drop zone cocok
            if (this.gameObject.tag == drag.correctDropTag)
            {
                drag.SetDropZone(transform); // Tempelkan di tempat yang benar
                dropped.transform.position = transform.position;
            }
            else
            {
                drag.ResetPosition(); // Balik ke posisi awal
            }
        }
    }
}

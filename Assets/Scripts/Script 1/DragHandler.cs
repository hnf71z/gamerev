using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform originalParent;
    private CanvasGroup canvasGroup;

    public string correctDropTag; // Tag dropzone yang benar
    public AudioSource wrongDropSound; // Suara saat drop salah

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // Jika belum dijatuhkan ke tempat yang benar, kembali ke posisi awal
        if (transform.parent == originalParent)
        {
            transform.position = startPosition;

            // Putar suara jika bukan tempat yang benar
            if (wrongDropSound != null)
            {
                wrongDropSound.Play();
            }
        }
    }

    public void SetDropZone(Transform newParent)
    {
        transform.SetParent(newParent);
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        transform.SetParent(originalParent);
    }
}

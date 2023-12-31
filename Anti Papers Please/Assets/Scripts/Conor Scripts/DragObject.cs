using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentAfterDrag;
    public bool IsSnap;
    public Image RayTarget;
    public AudioSource PickUpSound, PutDownSound;

    void Start()
    {
        if (RayTarget != null)
        {
            RayTarget.raycastTarget = true;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        transform.SetAsLastSibling();
        if(IsSnap)
        {
            RayTarget.raycastTarget = false;
        }
        PickUpSound.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        if (IsSnap)
        {
            if(parentAfterDrag != null && parentAfterDrag.GetComponent<SnapToGrid>() != null)
            {
                transform.DetachChildren();
                transform.SetParent(parentAfterDrag);
            }
            else
            {
                RayTarget.raycastTarget = true;
            }
        }
        PutDownSound.Play();
    }
}

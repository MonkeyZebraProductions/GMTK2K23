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
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        transform.SetAsLastSibling();
        if(IsSnap)
        {
            RayTarget.raycastTarget = false;
        }
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
                transform.SetParent(parentAfterDrag);
            }
            else
            {
                RayTarget.raycastTarget = true;
            }
        }
    }
}

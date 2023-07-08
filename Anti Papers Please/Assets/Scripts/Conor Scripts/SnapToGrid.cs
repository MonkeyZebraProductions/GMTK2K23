using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnapToGrid : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragObject dragObject = dropped.GetComponent<DragObject>();
        dragObject.parentAfterDrag = transform;
    }
}

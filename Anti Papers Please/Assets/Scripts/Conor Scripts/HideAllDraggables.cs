using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAllDraggables : MonoBehaviour
{
    public void Hide(bool IsHidden)
    {
        GameObject[] Draggables = FindObjectsOfType(typeof(DragObject), true) as GameObject[];

        foreach (GameObject Dra in Draggables )
        {
            Dra.SetActive(IsHidden);
        }
    }
}

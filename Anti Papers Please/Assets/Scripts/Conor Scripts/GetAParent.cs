using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAParent : MonoBehaviour
{
    public GameObject Parent;
    public Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        if(transform.parent == null)
        {
            GameObject newParent = Instantiate(Parent, transform.position, Quaternion.identity, canvas.transform);
            transform.SetParent(newParent.transform);
        }
    }
}

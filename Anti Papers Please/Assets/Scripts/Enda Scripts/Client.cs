using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : Person
{
    void Start()
    {
        PapersManager.instance.SpawnPapers(this, true, true, true, false, "Koletchia");
    }
}

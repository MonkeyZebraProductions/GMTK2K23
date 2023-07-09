using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : Person
{
    void Start()
    {
        //Randomise values for things client wants

        //Spawn those papers
        PapersManager.instance.SpawnPapers(this, true, true, true, false, PapersManager.Countries.Kanjo);
    }
}

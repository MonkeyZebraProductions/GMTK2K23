using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapersManager : MonoBehaviour
{
    public static PapersManager instance {get; private set;}

    private Person currentPerson;

    //ADD ARRAY FOR PAPERS
    private GameObject[] papers = new GameObject[4];

    private void Awake()
    {
        //Check if this is a duplicate singleton.
        if(instance != null && instance != this)
        {
            Debug.LogError("[PapersManager] Secondary singleton found. This should not happen.");
            Destroy(this);
        } else {
            instance = this;
        }
    }


    public void SpawnPapers(Person person, bool passport, bool idCard, bool visa, bool vehReg, string location)
    {
        currentPerson = person;
        if(passport)
            Debug.Log("[PapersManager] Spawned passport");
            //spawn Passport
        if(idCard)
            Debug.Log("[PapersManager] Spawned id card");
            //spawn Id Card
        if(visa)
            Debug.Log("[PapersManager] Spawned visa");
            //spawn visa
        if(vehReg)
            Debug.Log("[PapersManager] Spawned vehicle registration form");
            //spawn vehicle registration form.
    }
}

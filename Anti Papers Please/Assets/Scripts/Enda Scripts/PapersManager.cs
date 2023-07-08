using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapersManager : MonoBehaviour
{
    public static PapersManager instance {get; private set;}

    [SerializeField]
    private Transform passportParent;

    private Person currentPerson;

    [SerializeField]
    private List<GameObject> passports = new List<GameObject>();
    [SerializeField]
    private List<GameObject> idCards = new List<GameObject>();
    [SerializeField]
    private List<GameObject> visas = new List<GameObject>();
    [SerializeField]
    private GameObject vehicleReg;

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
        {
            Debug.Log("[PapersManager] Spawned passport");
            //spawn Passport
            Instantiate(passports[0],passportParent);
        }
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

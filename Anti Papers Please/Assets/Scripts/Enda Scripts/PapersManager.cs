using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapersManager : MonoBehaviour
{
    public static PapersManager instance {get; private set;}

    public enum Countries {
        Dawinkus,
        Kanjo,
        Lunky,
        Moosemin,
        Yashush
    }


    //The country hate list of lists
    private List<List<Countries>> bans = new List<List<Countries>>();


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
    private List<GameObject> papers = new List<GameObject>();

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

        //Initialise bans list
        //Dawinkus
        bans[0].Add(Countries.Moosemin);

        //Kanjo
        bans[1].Add(Countries.Yashush);
        bans[1].Add(Countries.Lunky);

        //Lunky
        bans[2].Add(Countries.Kanjo);
        bans[2].Add(Countries.Moosemin);

        //Moosemin
        bans[3].Add(Countries.Dawinkus);
        bans[3].Add(Countries.Lunky);
        bans[3].Add(Countries.Yashush);

        //Yashush
        bans[4].Add(Countries.Lunky);
    }


    public void SpawnPapers(Person person, bool passport, bool idCard, bool visa, bool vehReg, Countries location)
    {
        currentPerson = person;

        //print
        if(passport)
        {
            Debug.Log("[PapersManager] Spawned passport");
            //spawn Passport
            GameObject temp = Instantiate(passports[0],passportParent);
            papers.Add(temp);
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

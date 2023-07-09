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

    //Current Client details
    private Person currentPerson;
    //ADD ARRAY FOR PAPERS
    private List<GameObject> papers = new List<GameObject>();

    //All doccument types
    [SerializeField]
    private List<GameObject> passports = new List<GameObject>();
    [SerializeField]
    private List<GameObject> idCards = new List<GameObject>();
    [SerializeField]
    private List<GameObject> visas = new List<GameObject>();
    [SerializeField]
    private GameObject vehicleReg;


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

        //Initialise bans lists... oh dear list within list is scuffed
        bans.Add(new List<Countries>());
        bans.Add(new List<Countries>());
        bans.Add(new List<Countries>());
        bans.Add(new List<Countries>());
        bans.Add(new List<Countries>());

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

        int countryIndex = (int)location;
        Debug.Log("[Enda] Index is: "+countryIndex);

        GameObject temp;
        if(passport)
        {
            Debug.Log("[PapersManager] Spawned passport");
            //spawn Passport
            temp = Instantiate(passports[countryIndex],passportParent);
            papers.Add(temp);
        }
        if(idCard)
        {
            Debug.Log("[PapersManager] Spawned id card");
            //spawn Id Card
            temp = Instantiate(idCards[countryIndex],passportParent);
            papers.Add(temp);
        }
        if(visa)
        {
            Debug.Log("[PapersManager] Spawned visa");
            //spawn visa
            temp = Instantiate(visas[countryIndex],passportParent);
            papers.Add(temp);
        }
        if(vehReg)
        {
            Debug.Log("[PapersManager] Spawned vehicle registration form");
            //spawn vehicle registration form.
            temp = Instantiate(vehicleReg,passportParent);
            papers.Add(temp);
        }

        ValidatePapers();
    }

    public bool ValidatePapers()
    {
        //Compare each paper vs all others
        if(papers.Count != 1)
        {
            for(int i = 0; i<papers.Count-1; i++)
            {
                for(int j = i+1; j<=papers.Count-1; j++)
                {
                    //Debug.Log("[Enda] Compare: "+i+" and "+j);
                    ComparePapers(papers[i], papers[j]);
                }
            }
        }
        
        //Do card specific checks
        foreach(GameObject paper in papers)
        {
            /*Passport = 0
            Id = 1
            Visa = 2
            Veh Reg = 3
            */
            switch(/*paper.GetComponent<DocumentInfo>()*/1)
            {
                case 0:
                {

                    break;
                }
                case 1:
                {
                    
                    break;
                }
                case 2:
                {
                    
                    break;
                }
                case 3:
                {

                    break;
                }
            }
        }

        return false;
    }

    public bool ComparePapers(GameObject paper1, GameObject paper2)
    {
        //Here's where we're putting the validate code between 2 papers.


        return false;
    }

}

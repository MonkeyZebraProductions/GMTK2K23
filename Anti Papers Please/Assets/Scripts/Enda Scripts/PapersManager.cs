using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

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
    private Request currentRequest;
    private string currentErrors = "";
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


    //regex expressions
    private List<string> regexPassportNo = new List<string>();
    private List<string> regexIdNo = new List<string>();
    private List<string> regexVehicleIdNo = new List<string>();

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


        //Initialise regexs (D,K,L,M,Y)
        regexPassportNo.Add(@"[a-zA-Z][a-zA-Z]-[0-9][a-zA-Z]-[0-9][0-9]");
        regexPassportNo.Add(@"[0-9][0-9][0-9]-[0-9][0-9][0-9]");
        regexPassportNo.Add(@"[a-zA-Z][a-zA-Z][0-9]-[a-zA-Z][0-9][0-9]");
        regexPassportNo.Add(@"[0-9][0-9][0-9]-[0-9][0-9][a-zA-Z]");
        regexPassportNo.Add(@"[a-zA-Z][0-9]-[0-9][0-9]-[0-9][0-9]");

        regexIdNo.Add(@"[0-9][0-9]-[a-zA-Z][a-zA-Z]-[0-9][0-9]");
        regexIdNo.Add(@"[0-9][a-zA-Z]-[a-zA-Z][0-9]-[0-9][a-zA-Z]");
        regexIdNo.Add(@"[0-9][0-9][a-zA-Z]-[a-zA-Z][0-9][0-9]");
        regexIdNo.Add(@"[0-9][0-9][0-9]-[0-9][0-9][a-zA-Z]");
        regexIdNo.Add(@"[a-zA-Z][0-9]-[a-zA-Z][0-9]-[a-zA-Z][0-9]");

        regexVehicleIdNo.Add(@"[0-9][0-9][0-9]-[0-9][0-9][0-9]");
        regexVehicleIdNo.Add(@"[a-zA-Z][a-zA-Z]-[a-zA-Z][0-9]-[0-9][0-9]");
        regexVehicleIdNo.Add(@"[0-9][a-zA-Z][0-9]-[0-9][a-zA-Z][0-9]");
        regexVehicleIdNo.Add(@"[a-zA-Z][a-zA-Z]-[a-zA-Z][a-zA-Z]-[a-zA-Z][a-zA-Z]");
        regexVehicleIdNo.Add(@"[a-zA-Z][a-zA-Z][a-zA-Z]-[0-9][0-9][0-9]");


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


    public void SpawnPapers(Person person, bool passport, bool idCard, bool visa, bool vehReg, Request request)
    {
        currentPerson = person;

        int countryIndex = (int)request.passportStyle;
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
        bool valid = true;

        //Compare each paper vs all others
        if(papers.Count != 1)
        {
            for(int i = 0; i<papers.Count-1; i++)
            {
                for(int j = i+1; j<=papers.Count-1; j++)
                {
                    //Debug.Log("[Enda] Compare: "+i+" and "+j);
                    if(!ComparePapers(papers[i], papers[j]))
                        valid = false;
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
            
            DocumentInfo docScript = paper.GetComponent<DocumentInfo>();

            switch(docScript.DocumentType)
            {
                case 0:
                {
                    //Check pass number
                    if(!(Regex.Matches(docScript.PassportNo ,regexPassportNo[(int)currentRequest.passportStyle]).Count >0))
                    {
                        valid = false;
                        currentErrors += " Passport Number wrong";
                    }

                    //Check photo exists
                    if(docScript.PhotoChild == null || docScript.PhotoChild.name == "StampCanWork" || docScript.PhotoChild.name == "StampCantWork")
                    {
                        valid = false;
                        currentErrors += " Pasport photo Incorrect";
                    }
                    break;
                }
                case 1:
                {
                    //Check ID number
                    if(!(Regex.Matches(docScript.IDNo ,regexIdNo[(int)currentRequest.passportStyle]).Count >0))
                    {
                        valid = false;
                        currentErrors += " ID number wrong format";
                    }

                    //Check photo exists
                    if(docScript.PhotoChild == null || docScript.PhotoChild.name == "StampCanWork" || docScript.PhotoChild.name == "StampCantWork")
                    {
                        valid = false;
                        currentErrors += " ID photo Incorrect";
                    }
                    break;
                }
                case 2:
                {
                    //Check status correct
                    if(docScript.PhotoChild == null)
                    {
                        valid = false;
                        currentErrors += " Visa stamp missing";
                        //DO REQUESTS THING
                    } else {
                        if((currentRequest.visaCanWork == true && docScript.PhotoChild.name == "StampCantWork") 
                        || (currentRequest.visaCanWork == false && docScript.PhotoChild.name == "StampCanWork"))
                        {
                            valid = false;
                            currentErrors += " Wrong stamp used";
                        }
                    }
                    break;
                }
                case 3:
                {
                    //Check id format
                    if(!(Regex.Matches(docScript.VehicleReg ,regexVehicleIdNo[(int)currentRequest.passportStyle]).Count >0))
                    {
                        valid = false;
                        currentErrors += " Wrong car registration";
                    }

                    //Car type matches car.
                    if (currentPerson.car != docScript.VehicleValue)
                    {
                        valid = false;
                        currentErrors += " Wrong vehicle";
                    }
                    break;
                }
            }
        }

        return valid;
    }

    public bool ComparePapers(GameObject paper1, GameObject paper2)
    {
        //Here's where we're putting the validate code between 2 papers.


        return false;
    }

    public void ShowHidePapers(bool toggle)
    {
        foreach(GameObject paper in papers)
        {
            paper.SetActive(toggle);
        }
    }

}

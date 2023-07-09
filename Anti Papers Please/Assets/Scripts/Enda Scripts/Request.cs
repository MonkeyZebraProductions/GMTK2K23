using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request
{
    public string requestDialogue;

    public bool visaCanWork = true;

    public bool wantsPassport;
    public bool wantsId;
    public bool wantsVisa;
    public bool wantsVehReg;

    public PapersManager.Countries destination;
    public PapersManager.Countries passportStyle;



    public Request() {

        destination = (PapersManager.Countries) Random.Range(0, 4);
        requestDialogue += "I need to get into "+destination.ToString();

        passportStyle = (PapersManager.Countries) Random.Range(0, 4);
        requestDialogue += " with "+passportStyle.ToString()+" style documents";

        
        requestDialogue += " Get me these, quick! ";

        wantsPassport = (Random.value > 0.5f);
        wantsId = (Random.value > 0.5f);
        wantsVehReg = (Random.value > 0.5f);
        wantsVisa = (Random.value > 0.5f);
        visaCanWork = (Random.value > 0.5f);

        //In case they want nothing
        if(!wantsPassport && !wantsId && !wantsVehReg && !wantsVisa)
        {
            wantsPassport = true;
        }

        //Add to reqest dialogue
        if(wantsPassport)
            requestDialogue += "Passport ";
        if(wantsId)
            requestDialogue += "ID ";
        if(wantsVisa)
        {
            requestDialogue += "Visa ";
            if(visaCanWork)
            {
                requestDialogue += "for work ";
            } else {
                requestDialogue += "without work ";
            }
        }
        if(wantsVehReg)
        {
            requestDialogue += "Vehicle Registration";
        }
        
    }
}

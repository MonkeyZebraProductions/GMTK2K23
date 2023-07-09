using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : Person
{

    void Start()
    {
        if(!PapersManager.instance.papersHidden || !GameManager.instance.IsGearOut) //gonna have an or from game manager "isGearOut"
        {
            Speak("STOP RIGHT THERE CRIMINAL!");
            StartCoroutine(GameManager.instance.EndGameWithWait());
        } else {
            Speak("Just a routine check up... everything looks fine.");
        }

    }
}

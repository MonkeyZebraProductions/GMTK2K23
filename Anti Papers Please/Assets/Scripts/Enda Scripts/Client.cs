using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : Person
{
    private Request request = new Request();


    void Start()
    {
        Speak(request.requestDialogue);

        //Spawn those papers
        PapersManager.instance.SpawnPapers(this, 
                                        request.wantsPassport, 
                                        request.wantsId, 
                                        request.wantsVisa, 
                                        request.wantsVehReg, 
                                        request.passportStyle);
    }
}

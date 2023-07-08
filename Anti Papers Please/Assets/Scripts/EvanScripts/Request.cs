using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request
{
    public string requestDialogue;
    
    public enum RequestType
    {
        ID,
        Passport,
        Visa,
        Vehicle
    }
    public RequestType myRequestType;

    public Request() {
        requestDialogue = "This is a test";
        int randomType = Random.Range(0, 4); //Value shouldnt be hard coded but fuck it
        myRequestType = (RequestType)randomType; //Casting a random int into the request type which will give us a random value
    }
}

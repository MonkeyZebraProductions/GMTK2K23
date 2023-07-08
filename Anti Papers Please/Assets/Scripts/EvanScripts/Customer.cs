using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    private string[] customerNames =
    {
        "Bans Lunky",
        "Bans Moosemin",
        "Bans Yashush",
        "Bans Kanjo",
        "Bans Dawinkus"
    };
    public string customerName;
    
    public Request myRequest;

    public Customer() {
        customerName = customerNames[Random.Range(0, customerName.Length)];
        myRequest = new Request();
    }

    public void DisplayCustomerDetails() {
        Debug.Log("My name is: " + customerName + "\n"
                  + "My request is for: " + myRequest.myRequestType);
    }
    
}

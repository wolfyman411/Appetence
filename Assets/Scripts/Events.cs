using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
    public string eventName;
    public string eventDescription;

    public int moneyChange;


    public int stressChange;

    //Events affecting the player
    public Events(string name, string description, int moneyChange = 0, int stressChange = 0) 
    {
        eventName = name;
        eventDescription = description;
        this.moneyChange = moneyChange;
        this.stressChange = stressChange;
    }

    //Events with no affects
    public Events(string name, string description)
    {
        eventName = name;
        eventDescription = description;
    }

    //TODO: Events affecting family
    /* public Events(string name, string description, int moneyChange = 0) 
    {
        eventName = name;
        eventDescription = description;
        this.moneyChange = moneyChange;
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyMenuScript : MonoBehaviour
{
    [SerializeField]
    bool[] foodList;
    [SerializeField]
    bool[] medList;
    [SerializeField]
    private GameObject FamilyManager;
    private familyScript familyHandler;

    private void Start()
    {
        familyHandler = FamilyManager.GetComponent<familyScript>();
    }
    public void UpdateButton()
    {   
        familyHandler.DayUpdate(foodList, medList);
    }
    public void FoodButtons(int index)
    {
        if(foodList[index] == true){
            foodList[index] = false;
        }
        else if(foodList[index] == false){
            foodList[index] = true;
        }
    }
    public void MedButtons(int index)
    {
        if(medList[index] == true){
            medList[index] = false;
        }
        else if(medList[index] == false){
            medList[index] = true;
        }
    }
}

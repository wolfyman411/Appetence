using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    
    [SerializeField]
    private TMP_Text daysLasted;
    [SerializeField]
    Text[] familyList;
    // Start is called before the first frame update
    void Start()
    {
        daysLasted.text = "You Lasted " + familyScript.Instance.day.ToString() + " Days";

        //SetNames and States
        var i = 0;
        foreach (Text member in familyList)
        {
            member.text = familyScript.Instance.FamilyNames[i] + " - " + familyScript.Instance.HungerValues[familyScript.Instance.FamilyFoodState[i]] + " - " + familyScript.Instance.HealthValues[familyScript.Instance.FamilyHealthState[i]];
            i++;
        }
    }


    public void RestartButton()
    {
        SceneManager.LoadScene("Family");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}

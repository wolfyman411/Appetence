using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FamilyMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playUI;
    [SerializeField]
    private GameObject settingsUI;
    private bool SettingsMenu = false;

    [SerializeField]
    private GameObject tutorialText;


    [SerializeField]
    bool[] foodList;
    [SerializeField]
    bool[] medList;

    [SerializeField]
    Text[] familyList;

    [SerializeField]
    private TMP_Text currency;

    [SerializeField]
    private TMP_Text Medicine;
    [SerializeField]
    private TMP_Text totalCost;

    [SerializeField]
    private Button nextDayBtn;

    [SerializeField]
    private LevelLoader levelLoader;

    [SerializeField]
    private GameObject[] FoodTogList;

    [SerializeField]
    private GameObject[] MedTogList;

    [SerializeField]
    private int daysToWin = 10;

    [SerializeField]
    private string gameWonScene = "GameSurvived";

    [SerializeField]
    private AudioSource purchaseSFX;

    [SerializeField]
    private AudioClip foodPurchase;

	[SerializeField]
	private AudioClip medPurchase;


	[SerializeField]
    private TMP_Text dayDisplay;

    private int totalCostVal;

    public void Start()
    {
        currency.text = CurrencySystem.Instance.GetCurrency().ToString();

        dayDisplay.text = "Day " + familyScript.Instance.day.ToString();
        
        if (familyScript.Instance.day >= daysToWin)
        {
            SceneManager.LoadScene(gameWonScene);
        }

        if(familyScript.Instance.day > 0){
            Destroy(tutorialText);
        }
        
        //SetNames and States
        var i = 0;
        foreach (Text member in familyList)
        {
            member.text = familyScript.Instance.FamilyNames[i] + " - " + familyScript.Instance.HungerValues[familyScript.Instance.FamilyFoodState[i]] + " - " + familyScript.Instance.HealthValues[familyScript.Instance.FamilyHealthState[i]];
            if(familyScript.Instance.FamilyHealthState[i] == 1 || familyScript.Instance.FamilyHealthState[i] == 2){
                MedTogList[i].SetActive(true);
            }
            if(familyScript.Instance.FamilyHealthState[i] == 3 || familyScript.Instance.FamilyFoodState[i] == 3){
                FoodTogList[i].SetActive(false);
                MedTogList[i].SetActive(false);
            }
            i++;
        }
    }

    public void Update()
    {
        totalCost.text = CalcTotal().ToString();

        if (CurrencySystem.Instance.GetCurrency() < CalcTotal() && CalcTotal() != 0)
        {
            totalCost.text = "TOO MUCH!";
            nextDayBtn.transform.localScale = Vector3.zero;
        }
        else
        {
            nextDayBtn.transform.localScale = Vector3.one;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            MenuChange();
        }
        if (Input.GetMouseButtonDown(0)){
            Destroy(tutorialText);
        }
    }
    public void MenuChange()
    {
        if(SettingsMenu){
            playUI.SetActive(true);
            settingsUI.SetActive(false);
            SettingsMenu = false;
        }
        else{
            playUI.SetActive(false);
            settingsUI.SetActive(true);
            SettingsMenu = true;
        }
        
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    
    public void UpdateButton()
    {
        bool dead = familyScript.Instance.DayUpdate(foodList, medList);
        CurrencySystem.Instance.AddCurrency(-CalcTotal());
        if(dead){
            SceneManager.LoadScene("GameOver");
        }
        else{
            StartCoroutine(levelLoader.LoadLevel("Factory"));
        }
    }
    public void FoodButtons(int index)
    {
        if(foodList[index] == true){
            foodList[index] = false;
        }
        else if(foodList[index] == false){
			purchaseSFX.clip = foodPurchase;
			purchaseSFX.Play();
			foodList[index] = true;
        }
    }
    public void MedButtons(int index)
    {
        if(medList[index] == true){
            medList[index] = false;
        }
        else if(medList[index] == false){
            purchaseSFX.clip = medPurchase;
            purchaseSFX.Play();
            medList[index] = true;
        }
    }

    private int CalcTotal()
    {
        totalCostVal = 0;
        foreach (var item in foodList)
        {
            if (item)
            {
                totalCostVal += 60;
            }
        }
        foreach (var item in medList)
        {
            if (item)
            {
                totalCostVal += 200;
            }
        }

        if (CurrencySystem.Instance.GetCurrency() < 0 && totalCostVal <= 0)
        {
            return 0;
        }

        return totalCostVal;
    }
}

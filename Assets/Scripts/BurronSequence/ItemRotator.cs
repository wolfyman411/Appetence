using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemRotator : MonoBehaviour
{
    [SerializeField]
    private GameObject playUI;
    [SerializeField]
    private GameObject settingsUI;
    private bool SettingsMenu = false;
    public List<ItemObjects> objects;
    public ItemReader itemReader;
    public ButtonSequencer buttonSequencer;
    private bool tutorial = false;
    [SerializeField]
    private TMP_Text tutorialText;

    //private bool isworking = true;
    private ItemObjects item;

    [SerializeField]
    private TMP_Text currencyDisplay;

    // Start is called before the first frame update
    void Start()
    {
        item = itemReader.item = objects[Random.Range(0, objects.Count)];
        var allSequence = "";
        for (int i = 0; i < objects.Count; i++)
        {
            allSequence += objects[i].itemName + ": " + objects[i].itemSequence + "\n";
        }
        itemReader.itemSequence.text = allSequence;
    }

    // Update is called once per frame
    void Update()
    {
        currencyDisplay.text = CurrencySystem.Instance.GetCurrency().ToString();
        if(Input.GetKeyDown(KeyCode.Escape)){
            MenuChange();
        }
        if (buttonSequencer.GetNumberSequence().Length <= 0)
        {
            return;
        }

        if (buttonSequencer.GetNumberSequence()[buttonSequencer.GetNumberSequence().Length-1] != itemReader.item.itemSequence[buttonSequencer.GetNumberSequence().Length-1])
        {
            Debug.Log("Wrong");
            StartCoroutine(itemReader.CorrectnessDisplay("Wrong"));
            buttonSequencer.ClearNumberSequence();

            CurrencySystem.Instance.AddCurrency(-50);
        }
        else if (buttonSequencer.GetNumberSequence().Length == itemReader.item.itemSequence.Length)
        {
            Debug.Log("Correct");
            item = itemReader.item = objects[Random.Range(0, objects.Count)];
            StartCoroutine(itemReader.CorrectnessDisplay("Correct"));
            buttonSequencer.ClearNumberSequence();

            CurrencySystem.Instance.AddCurrency(35);
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
    public void TutorialButton()
    {
       if(tutorial){
            tutorialText.enabled = false;
            tutorial = false;
        }
        else{
            tutorialText.enabled = true;
            tutorial = true;
        }
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}

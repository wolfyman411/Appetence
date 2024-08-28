using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ItemRotator : MonoBehaviour
{
    [SerializeField]
    private GameObject buttons;
    private bool showButtons = true;
    [SerializeField]
    private GameObject playUI;
    [SerializeField]
    private GameObject settingsUI;
    private bool SettingsMenu = false;

    public List<ItemObjects> objects;
    public List<ItemObjects> chosenObjects;

    public ItemReader itemReader;
    public ButtonSequencer buttonSequencer;

    [SerializeField]
    private TMP_Text tutorialText;

    //private bool isworking = true;
    private ItemObjects item;

    [SerializeField]
    private TMP_Text currencyDisplay;

    [SerializeField]
    private AudioSource audioBuzzer;

    [SerializeField]
    private AudioClip correctSound;

    [SerializeField]
    private AudioClip failSound;

    // Start is called before the first frame update
    void Start()
    {
        if(familyScript.Instance.day > 1){
            tutorialText.enabled = false;
        }

        //Difficulty handler
        int maxItem = Mathf.Clamp(familyScript.Instance.day + 3,0, objects.Count);
        for (int i = 0; i < 4; i++)
        {
            chosenObjects.Add(objects[Random.Range(0, maxItem)]);
        }

        item = itemReader.item = chosenObjects[Random.Range(0, chosenObjects.Count)];
        var allSequence = "";
        for (int i = 0; i < chosenObjects.Count; i++)
        {
            allSequence += chosenObjects[i].itemName + ": " + chosenObjects[i].itemSequence + "\n";
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
        if (Input.GetMouseButtonDown(0)){
            tutorialText.enabled = false;
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

            audioBuzzer.clip = failSound;
            audioBuzzer.Play();
        }
        else if (buttonSequencer.GetNumberSequence().Length == itemReader.item.itemSequence.Length)
        {
            Debug.Log("Correct");
            item = itemReader.item = chosenObjects[Random.Range(0, chosenObjects.Count)];
            StartCoroutine(itemReader.CorrectnessDisplay("Correct"));
            buttonSequencer.ClearNumberSequence();

            CurrencySystem.Instance.AddCurrency(35);

            audioBuzzer.clip = correctSound;
            audioBuzzer.Play();
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
    public void InstructionButton()
    {
        if(showButtons){
            showButtons = false;
            buttons.SetActive(false);
        }
        else{
            showButtons = true;
            buttons.SetActive(true);
        }
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        familyScript.Instance.Reset();

        SceneManager.LoadScene("Main Menu");
    }
}

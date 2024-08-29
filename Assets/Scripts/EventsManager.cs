using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EventsManager : MonoBehaviour
{
    public List<Events> events = new List<Events>();
    public GameObject panel;
    public TextMeshProUGUI descriptionText;
    private CurrencySystem currencySystem;
    private Scene currentScene;

    private void Start()
    {
        currencySystem = FindObjectOfType<CurrencySystem>();
        currentScene = SceneManager.GetActiveScene();
        
        // Add events
        events.Add(new Events("Car Breakdown", "Your car broke down, and you had to pay 50 for repairs.", -50, 0));
        events.Add(new Events("Lucky Find", "You found 40 on the floor!", 40, 0));

        OnSceneLoaded();

    }
    public void TriggerRandomEvent()
    {
        if (events.Count == 0) return;

        int randomIndex = Random.Range(0, events.Count);
        Events selectedEvent = events[randomIndex];

        OpenPanel(selectedEvent.eventDescription);
        AffectPlayer(selectedEvent);
       // Debug.Log("Show panel");
    }

    public void OpenPanel(string description)
    {
        panel.SetActive(true);
        descriptionText.text = description;
    }

    public void AffectPlayer(Events selectedEvent)
    {
        currencySystem.AddCurrency(selectedEvent.moneyChange);
       // Debug.Log("Affecting player");
    }

    private void OnSceneLoaded()
    {
        // Check if the loaded scene is the family scene
        if (currentScene.name == "Family")
        {
           // Debug.Log("Checked scene: Family");
            // Show the random event
            if (familyScript.Instance.getDay() != 0)
            {
                //Debug.Log("Triggered");
                TriggerRandomEvent();
            }
        }
    }

    public void ExitPanel()
    {
        panel.SetActive(false);
    }
}

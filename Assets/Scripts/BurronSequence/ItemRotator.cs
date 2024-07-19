using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemRotator : MonoBehaviour
{
    public List<ItemObjects> objects;
    public ItemReader itemReader;
    public ButtonSequencer buttonSequencer;

    private bool isworking = true;
    private ItemObjects item;

    [SerializeField]
    private TMP_Text currencyDisplay;

    // Start is called before the first frame update
    void Start()
    {
        item = itemReader.item = objects[Random.Range(0, objects.Count)];
        StartCoroutine(itemReader.ShowItemSequence());
    }

    // Update is called once per frame
    void Update()
    {
        currencyDisplay.text = CurrencySystem.Instance.GetCurrency().ToString();

        if (buttonSequencer.GetNumberSequence().Length <= 0)
        {
            return;
        }

        if (buttonSequencer.GetNumberSequence()[buttonSequencer.GetNumberSequence().Length-1] != itemReader.item.itemSequence[buttonSequencer.GetNumberSequence().Length-1])
        {
            Debug.Log("Wrong");
            StartCoroutine(itemReader.ShowItemSequence());
            buttonSequencer.ClearNumberSequence();

            CurrencySystem.Instance.AddCurrency(-50);
        }
        else if (buttonSequencer.GetNumberSequence().Length == itemReader.item.itemSequence.Length)
        {
            Debug.Log("Correct");
            item = itemReader.item = objects[Random.Range(0, objects.Count)];
            StartCoroutine(itemReader.ShowItemSequence());
            buttonSequencer.ClearNumberSequence();

            CurrencySystem.Instance.AddCurrency(35);
        }
    }
}

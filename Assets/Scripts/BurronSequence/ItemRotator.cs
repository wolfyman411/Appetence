using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    public List<ItemObjects> objects;
    public ItemReader itemReader;
    public ButtonSequencer buttonSequencer;

    private bool isworking = true;
    private ItemObjects item;
    // Start is called before the first frame update
    void Start()
    {
        item = itemReader.item = objects[Random.Range(0, objects.Count)];
        StartCoroutine(itemReader.ShowItemSequence());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (buttonSequencer.GetNumberSequence().Length >= itemReader.itemLength)
        {
            if(buttonSequencer.GetNumberSequence() == item.itemSequence)
            {
                Debug.Log("Correct");
                item = itemReader.item = objects[Random.Range(0, objects.Count)];
                StartCoroutine(itemReader.ShowItemSequence());
                buttonSequencer.ClearNumberSequence();
            }
            else
            {
                Debug.Log("Wrong");
                StartCoroutine(itemReader.ShowItemSequence());
                buttonSequencer.ClearNumberSequence();
            }
        }
    }
}

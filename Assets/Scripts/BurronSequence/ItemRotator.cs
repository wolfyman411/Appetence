using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    public List<ItemObjects> objects;
    public ItemReader itemReader;
    public ButtonSequencer buttonSequencer;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemReader.item = objects[index];
        if (buttonSequencer.GetNumberSequence().Length >= itemReader.itemLength)
        {
            if(buttonSequencer.GetNumberSequence() == objects[index].itemSequence)
            {
                Debug.Log("Correct");
                buttonSequencer.ClearNumberSequence();
                index++;
            }
            else
            {
                Debug.Log("Wrong");
                buttonSequencer.ClearNumberSequence();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonSequencer : MonoBehaviour
{
    public ItemReader itemReader;
    public List<ButtonScript> sequenceButtons;
    private List<int> numSequence = new List<int>();

    [SerializeField]
    private TMP_Text displayString;

    void Start()
    {
        for (int i = 0; i < sequenceButtons.Count; i++)
        {
            int index = i;
            sequenceButtons[index].button.onClick.AddListener(() => OnButtonClicked(sequenceButtons[index]));

        }
    }

    private void Update()
    {

    }
    void OnButtonClicked(ButtonScript clickedButton)
    {
        if (!itemReader.seeSequence)
        {
            numSequence.Add(clickedButton.GetNumber());
        }
        Debug.Log("Number Sequence: " + GetNumberSequence());
        displayString.text = "Number Sequence: " + GetNumberSequence();
    }

    public string GetNumberSequence()
    {
        return string.Join("", numSequence);
    }

    public void ClearNumberSequence()
    {
        numSequence.Clear();
    }
}

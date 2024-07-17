using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class ButtonSequencer : MonoBehaviour
{
    public List<ButtonScript> sequenceButtons;
    private List<int> numSequence = new List<int>();

    void Start()
    {
        for (int i = 0; i < sequenceButtons.Count; i++)
        {
            int index = i;
            sequenceButtons[i].button.onClick.AddListener(() => OnButtonClicked(sequenceButtons[index]));

        }
    }

    private void Update()
    {

    }
    void OnButtonClicked(ButtonScript clickedButton)
    {
        numSequence.Add(clickedButton.GetNumber());
        Debug.Log("Number pressed: " + clickedButton.GetNumber());
        Debug.Log("Number Sequence: " + GetNumberSequence());
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

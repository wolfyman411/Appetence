using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemReader : MonoBehaviour
{
    public ItemObjects item;
    public TMP_Text itemName;
    public TMP_Text itemSequence;
    public Image itemImage;
    public int itemLength;
    [SerializeField]
    private float waitDuration;
    // Start is called before the first frame update
    void Update()
    {
        itemName.text = item.itemName;
        itemSequence.text = item.itemSequence;
        itemLength = item.itemSequence.Length;
        itemImage.sprite = item.itemSprite;
    }

    public IEnumerator ShowItemSequence()
    {
        itemSequence.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitDuration);
        itemSequence.gameObject.SetActive(false);
    }
}

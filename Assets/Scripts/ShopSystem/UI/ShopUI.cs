using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShopUI : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemCost;
    public Toggle toggleItem;
    public Image itemIcon;
    public Button buyButton;

    private ShopItem currentItem;
    public void Setup(ShopItem item)
    {
        currentItem = item;
        itemName.text = item.itemName;  // Assign item name
        itemCost.text = item.cost.ToString();  // Assign item cost
        itemIcon.sprite = item.itemIcon;  // Assign item icon
        buyButton.onClick.AddListener(BuyItem);

    }

    void BuyItem()
    {
        //add code about buying
        Debug.Log("Bought Item");
    }
}

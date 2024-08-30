using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShopUI : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public TMP_Text itemCost;
    public Toggle toggleItem;
    public Image itemIcon;
    public Button buyButton;
    private ShopItem currentItem;
    private List<ShopItem> boughtItems = new List<ShopItem>();

    public void Setup(ShopItem item)
    {
        currentItem = item;
        itemName.text = item.itemName;  // Assign item name
        itemDescription.text = item.itemDescription;  // Assign item description
        itemCost.text = item.cost.ToString();  // Assign item cost

        // Load the availability state
        bool savedAvailability = PlayerPrefs.GetInt(currentItem.itemName + "_available", item.available ? 1 : 0) == 1;
        toggleItem.isOn = savedAvailability;
        currentItem.available = savedAvailability;

        itemIcon.sprite = item.itemIcon;  // Assign item icon
        buyButton.onClick.AddListener(BuyItem);
    }

    void BuyItem()
    {
        if (currentItem.available == true)
        {
            SetAvailability(false);
            CurrencySystem.Instance.AddCurrency(-currentItem.cost);
            boughtItems.Add(currentItem);
        }
        else
        {
            Debug.Log("Not Available");
        }
    }

    public void SetAvailability(bool available)
    {
        currentItem.available = available;
        toggleItem.isOn = available;
        // Save the availability state
        PlayerPrefs.SetInt(currentItem.itemName + "_available", available ? 1 : 0);
        PlayerPrefs.Save();
    }
}

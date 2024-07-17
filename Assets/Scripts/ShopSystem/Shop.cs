using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private ShopItem[] shopItems;

    [SerializeField]
    private GameObject shopIcon;

    [SerializeField]
    private GameObject vertContainer;
    // Start is called before the first frame update
    void Start()
    {
        foreach (ShopItem shop in shopItems)
        {
            //Setup
            GameObject newItem = Instantiate(shopIcon);
            ShopUI icon = shopIcon.GetComponent<ShopUI>();

            //Create new slot
            icon.itemName.text = shop.itemName;
            icon.itemCost.text = shop.cost.ToString();
            icon.itemIcon.sprite = shop.itemIcon;

            newItem.transform.parent = vertContainer.transform;
        }
    }
}

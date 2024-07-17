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


    //TESTING VARS
    private int aliveFamily = 0;
    private int sickFamily = 0;


    // Start is called before the first frame update
    void Start()
    {
        var i = 0; //TEMP
        aliveFamily = Random.Range(1, 5);
        sickFamily = Random.Range(0, aliveFamily);

        foreach (ShopItem shop in shopItems)
        {
            //Setup
            GameObject newItem = Instantiate(shopIcon);
            ShopUI icon = newItem.GetComponent<ShopUI>();

            //Create new slot
            icon.itemName.text = shop.itemName;


            //LOGIC PER ITEM (TEMP)
            if (i == 0)//Food
            {
                icon.itemCost.text = (shop.cost* aliveFamily).ToString();
                newItem.transform.parent = vertContainer.transform;
            }
            else //Med
            {
                icon.itemCost.text = (shop.cost * sickFamily).ToString();
                if (sickFamily > 0)
                {
                    newItem.transform.parent = vertContainer.transform;
                }
                else
                {
                    Destroy(newItem);
                }
            }
            icon.itemIcon.sprite = shop.itemIcon;
            i++;
        }

        Debug.Log("alive "+aliveFamily);
        Debug.Log("sick "+sickFamily);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public float currency{ get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject.transform);
    }

    public bool AddCurrency(float amount)
    {
        //Check if negative
        if (amount < 0)
        {
            if (amount + currency < 0)
            {
                return false;
            }
            else
            {
                currency += amount;
                return true;
            }
        //Positive
        }
        else
        {
            currency += amount;
            return true;
        }
    }
}

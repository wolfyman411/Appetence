using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    private int currency = 350;

    public static CurrencySystem Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            //Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void AddCurrency(int amount)
    {
        if(currency + amount > 0){
            currency += amount;
        }
        else{
            currency = 0;
        }
    }

    public int GetCurrency()
    {
        return currency;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private int currentCurrency;
    public int CurrentcyCount
    {
        get { return currentCurrency;}
        set { currentCurrency = value; }
    }

    private void Update()
    {//this is a placeholder 
        Debug.Log(currentCurrency);
    }

    public void SetCurrencyCount(int amount)
    {
        CurrentcyCount += amount;
    }
    public void AddCurrency(int amount)
    {
        CurrentcyCount += amount;
    }
}

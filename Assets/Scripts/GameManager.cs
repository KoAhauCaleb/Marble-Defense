using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int money;
    
    // Start is called before the first frame update
    void Start()
    {
        money = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Increase users money.
    /// </summary>
    public void AddMoney(int moneyGain)
    {
        money += moneyGain;
    }

    /// <summary>
    /// Decrease users money. Returns false if not enough money.
    /// </summary>
    public bool SpendMoney(int moneySpent)
    {
        if (money < moneySpent)
        {
            return false;
        }

        money -= moneySpent;
        return true;
    }

    /// <summary>
    /// Check if there is enough money available.
    /// </summary>
    public bool CheckMoney(int moneyNeeded)
    {
        return money >= moneyNeeded;
    }

    /// <summary>
    /// Get the amount of money.
    /// </summary>
    public int getMoney()
    {
        return money;
    }
}

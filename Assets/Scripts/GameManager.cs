using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;
    private static int money;
    public Rigidbody2D enemy;
    public float timeRemaining = 1f;
    public float spawnSpeed = 1f;


    
    // Start is called before the first frame update
    void Start()
    {
        money = 200;
        updateMoneyDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn an enemy whenever timer reaches zero.
        if (timeRemaining > 0)
        {
            // Decrease timer.
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            // Spawm enemy and reset timer.
            Spawn();
            timeRemaining = (1 / spawnSpeed); 
        }

    }

    /// <summary>
    /// Spawn a new enwmy.
    /// </summary>
    void Spawn()
    {
        Rigidbody2D clone;
        clone = Instantiate(enemy);
        clone.velocity = transform.TransformDirection(Vector2.up * 20);
    }

    /// <summary>
    /// Increase users money.
    /// </summary>
    public void AddMoney(int moneyGain)
    {
        money += moneyGain;
        updateMoneyDisplay();
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
        updateMoneyDisplay();
        return true;
    }

    /// <summary>
    /// Updates the money display with current money amount. Call whenever changed.
    /// </summary>
    void updateMoneyDisplay()
    {
        moneyDisplay.text = "Money: " + money;
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

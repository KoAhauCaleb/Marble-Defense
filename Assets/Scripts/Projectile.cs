using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{      
    int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // If the object collided with is an enemy, deal damage.
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit enemy");
            Enemy enemy = col.gameObject.GetComponent(typeof(Enemy)) as Enemy;
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}

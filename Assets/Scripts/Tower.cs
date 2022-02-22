using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public Rigidbody2D projectile;

    public float timeRemaining = 1f;
    public float shootingSpeed = 1f;

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        // Get game manager.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Get nearest enemy.

        // TODO: Change mouse pos to enemy position.
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;

        // Shoot Projectile.
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Shoot();
            timeRemaining = (1 / shootingSpeed); 
        }

    }

    void Shoot()
    {
        Rigidbody2D clone;
        clone = Instantiate(projectile, transform.position, transform.rotation);
        clone.velocity = transform.TransformDirection(Vector2.up * 20);
    }

    void OnMouseDown(){
        if(gameManager.SpendMoney(100)){
            shootingSpeed *= 2;
        }
    }   
}

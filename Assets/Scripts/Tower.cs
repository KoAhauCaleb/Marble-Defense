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

        // Get direction towards mouse and point tower towards it.
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;

        // Shoot projectile based on shooting speed.
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

    /// <summary>
    /// Shoot a projectile in the direction the tower is pointing.
    /// </summary>
    void Shoot()
    {
        Rigidbody2D clone;
        clone = Instantiate(projectile, transform.position, transform.rotation);
        clone.velocity = transform.TransformDirection(Vector2.up * 20);
    }

    void OnMouseDown(){
        // Attemp an upgrade if the user clicks on this object.
        if(gameManager.SpendMoney(100)){
            shootingSpeed *= 2;
        }
    }   
}

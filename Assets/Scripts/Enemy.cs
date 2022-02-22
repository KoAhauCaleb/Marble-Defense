using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameManager gameManager;
    private Vector2 heading;
    private float speed = 1.0f; // Units per second.
    private Queue path = new Queue();

    public int health = 200;

    // Start is called before the first frame update
    void Start()
    {
        // Get game manager.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Create path.
        // TODO: Move to GameManager when ready.
        path.Enqueue(new Vector2(-5f, 2.5f));
        enqueue90DegreeLeftDownPath(new Vector2(-5f, 2.5f), new Vector2(-5.5f, 2f), 12);
        path.Enqueue(new Vector2(-5.5f, 1f));
        enqueue90DegreeDownRightPath(new Vector2(-5.5f, 1f), new Vector2(-5f, .5f), 12);
        path.Enqueue(new Vector2(4f, .5f));
        enqueue90DegreeRightDownPath(new Vector2(4f, .5f), new Vector2(4.5f, 0f), 12);
        path.Enqueue(new Vector2(4.5f, -1f));
        enqueue90DegreeDownLeftPath(new Vector2(4.5f, -1f), new Vector2(4f, -1.5f), 12);
        updateHeading();
        path.Enqueue(new Vector2(-5f, -1.5f));
        enqueue90DegreeLeftDownPath(new Vector2(-5f, -1.5f), new Vector2(-5.5f, -2f), 12);
        path.Enqueue(new Vector2(-5.5f, -3f));
        enqueue90DegreeDownRightPath(new Vector2(-5.5f, -3f), new Vector2(-5f, -3.5f), 12);
        path.Enqueue(new Vector2(7f, -3.5f));
    }

    void enqueue90DegreeLeftDownPath(Vector2 start, Vector2 end, int definition)
    {   
        //Find difference between angles.
        float angleStep = (90.0f / definition) * Mathf.Deg2Rad;
        float radius = start.x - end.x;
        float center_x = start.x;
        float center_y = end.y;

        // Add vectors until                                                                     
        for (int i = 1; i <= definition; i++)
        {
            float y = radius * Mathf.Cos(angleStep * i);
            float x = radius * Mathf.Sin(angleStep * i);
            
            path.Enqueue(new Vector2(center_x - x, center_y + y));
        }

    }

    void enqueue90DegreeDownRightPath(Vector2 start, Vector2 end, int definition)
    {   
        //Find difference between angles.
        float angleStep = (90.0f / definition) * Mathf.Deg2Rad;
        float radius = start.x - end.x;
        float center_x = end.x;
        float center_y = start.y;

        // Add vectors until                                                                     
        for (int i = 1; i <= definition; i++)
        {
            float x = radius * Mathf.Cos(angleStep * i);
            float y = radius * Mathf.Sin(angleStep * i);
            
            path.Enqueue(new Vector2(center_x + x, center_y + y));
        }
    }

    void enqueue90DegreeRightDownPath(Vector2 start, Vector2 end, int definition)
    {   
        //Find difference between angles.
        float angleStep = (90.0f / definition) * Mathf.Deg2Rad;
        float radius = start.x - end.x;
        float center_x = start.x;
        float center_y = end.y;

        // Add vectors until                                                                     
        for (int i = 1; i <= definition; i++)
        {
            float y = radius * Mathf.Cos(angleStep * i);
            float x = radius * Mathf.Sin(angleStep * i);
            
            path.Enqueue(new Vector2(center_x - x, center_y - y));
        }

    }

    void enqueue90DegreeDownLeftPath(Vector2 start, Vector2 end, int definition)
    {   
        //Find difference between angles.
        float angleStep = (90.0f / definition) * Mathf.Deg2Rad;
        float radius = start.x - end.x;
        float center_x = end.x;
        float center_y = start.y;

        // Add vectors until                                                                     
        for (int i = 1; i <= definition; i++)
        {
            float x = radius * Mathf.Cos(angleStep * i);
            float y = radius * Mathf.Sin(angleStep * i);
            
            path.Enqueue(new Vector2(center_x + x, center_y - y));
        }

    }

    // FixedUpdate is called 60 times a second.
    void FixedUpdate()
    {
        Vector2 relHeading = heading - (Vector2)transform.position;
        float distance = relHeading.magnitude;
        var direction = relHeading / distance; // This is now the normalized direction.

        if (distance > speed / 60)
        {
            // TODO: Move by speed.
            float moveDistance = speed / 60;
            transform.position = Vector2.MoveTowards(transform.position, heading, moveDistance);
        }
        else
        {
            // TODO: Move by distance. Update heading to next component in path if there is one.
            // Move remaining speed.
            
            while (false) {

            }
        }

        // TODO: If position equals heading, set heading to next in path.
        if (distance < speed / 60)
        {
            updateHeading();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateHeading()
    {
        if(path.Count > 0)
        {
            heading = (Vector2)path.Dequeue();
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.AddMoney(20);
        }
    }
}

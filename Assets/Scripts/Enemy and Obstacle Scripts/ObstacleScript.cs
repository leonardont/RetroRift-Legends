using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    public int speed = 0; //Sets the initial speed to 0 initially, to avoid errors. Changes below.
    public int timeDestroy = 1; //Sets the destroy time for the enemy to 1 initially, to avoid errors. Changes below.

    public int livesTaken = 1; //Sets the lives taken upon every hit to the obstacles to 1.

    void Start()
    {

        if (gameObject.tag == ("marioTag")) //If the obstacle has the Mario tag...
        {
            speed = 3; //Sets the enemy speed.
            timeDestroy = 7; //Sets the time needed to destroy the prefab in seconds.
            livesTaken = 1; //Sets the lives it takes from the player upon hitting it.
        } 
        else if (gameObject.tag == ("sonicTag")) //If the obstacle has the Sonic tag...
        {
            speed = -3;
            timeDestroy = 7;
            livesTaken = 1;
        }

        SetRigidBody();

        Destroy(gameObject, timeDestroy); //Destroys the enemy in the previously scripted time.

    }

    void Update()
    {
        
    }

    void SetRigidBody()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D> (); //Gets and sets the Rigidbody of the prefab.
        rb.velocity = new Vector2(speed, 0); //Gives it the speed value at the Y angle.
    }

}

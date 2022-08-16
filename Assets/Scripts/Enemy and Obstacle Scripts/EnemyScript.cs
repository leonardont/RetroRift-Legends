using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int speed = 0; //Sets the initial speed to 0 initially, to avoid errors. Changes below.
    public int timeDestroy = 1; //Sets the destroy time for the enemy to 1 initially, to avoid errors. Changes below.

    private PointsScript ptScript; //Pulls the Points Script to integrate the points you receive by hitting the enemies.
    public int enemyPoints = 0; //Sets the points received to 0 initially, to avoid errors. Changes below.

    void Start()
    {

        if (gameObject.tag == ("goombaTag")) //If the enemy prefab has the goomba tag...
        {
            speed = -2; //Changes its speed to -2, which makes its speed normal.
            timeDestroy = 7; //Changes the time in seconds to destroy the enemy prefab, preventing it from lagging the game if not destroyed or disappearing before leaving the screen.
            enemyPoints = 100; //Sets the value in points which it gives to the player upon hitting it.
        } 
        else if (gameObject.tag == ("knightTag")) //If the enemy prefab has the knight tag...
        {
            speed = -1; //Changes its speed to -1, which makes it a little slow.
            timeDestroy = 15;
            enemyPoints =  300;
        } 
        else if (gameObject.tag == ("motobugTag")) //If the enemy prefab has the motobug tag...
        {
            speed = -4; //Changes its speed to -4, which makes it faster.
            timeDestroy = 6;
            enemyPoints = 200;
        }

        SetRigidBody();

        Destroy(gameObject, timeDestroy); //Destroys the enemy in the previously scripted time.

        ptScript = GameObject.Find("score").GetComponent<PointsScript>(); //Used to find the score at the UI and refresh it.

    }

    void Update()
    {
        
    }

    void SetRigidBody()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D> (); //Gets and sets the Rigidbody of the prefab.
        rb.velocity = new Vector2(0, speed); //Gives it the speed value at the Y angle.
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.tag == "bulletTag") //If the collider is activated by the bullet...
        {
            Destroy(this.gameObject); //Destroys the enemy.
            Destroy(other.gameObject); //Destroys the bullet.
            ptScript.points += enemyPoints; //Increases the points of the player, following the points of which enemy was destroyed, as scripted before.
        }
    }

}

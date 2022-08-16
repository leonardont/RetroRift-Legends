using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    public float speed = 9.5f; //Determines the speed of the bullet.
    private CharacterScript character; //Pulls the character script, to a posterior utilization.

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D> (); //Gets and sets the Rigidbody.
        rb.velocity = new Vector2(0, speed); //Sets the velocity of the Rigidbody, to be determined at 0 for the X angle and the speed value for the Y angle.

        character = GameObject.Find("character").GetComponent<CharacterScript>(); //Links the bullet to the character script, so it can be launched from the character in the game.
    }

    void Update()
    {
        
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject); //Destroys the bullet when it leaves the screen, to prevent lag.
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.tag == "marioTag" || other.gameObject.tag == "sonicTag") //If the object has the "Mario" tag or the "Sonic" tag (obstacles), it destroys the bullet and calls the "die" function from the character script.
        {
            Destroy(this.gameObject);
            character.die();
        }
    }

}

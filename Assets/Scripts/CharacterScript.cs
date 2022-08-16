using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    
    public GameObject blaster; //The game uses a empty box for the blaster (gun) of the character, to correct the bullet launch position. This function is linked to this empty box.
    public GameObject bullet; //The bullet variable, for linking to the bullet prefab.

    public Animator animator; //Used in the animations of the caracter.

    public float speed = 6f; //Character movement speed.
    float horizontal = 0f; //Sets the horizontal value to 0f, to prevent problems at the posterior function.
    float vertical = 0f; //Sets the vertical value to 0f, to prevent problems at the posterior function.

    public int lives = 5; //Sets the initial lives of the character to 5.
    public Text livesUI; //Grabs the UI text to display it correctly at the screen.

    void Start()
    {
        livesUI.text = "Lives: " + lives; //Displays the lives text with the lives variable at the UI, pulled at the start of the level.
    }

    void Update()
    {
        MoveHorizontal(); //Calls the move horizontal function.

        MoveVertical(); //Calls the move vertical function.

        PlayerAttack(); //Calls the player attack function.

        PreventLeavingScreen(); //Calls the prevent leaving screen function.

        if((Input.GetAxis("Horizontal") == 0) && (Input.GetAxis("Vertical") == 0)) //This condition is used to determine if the animator should play the "moving" animation or not, based on if the player is moving horizontally/vertically or not.
        {
            animator.SetBool("Moving", false); //If horizontal and vertical = 0 (not moving), the bool is set to false, not displaying any new animation for the character.
        }
    }

    void MoveHorizontal()
    {
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //This gets the horizontal axis, multiplies it for the speed of the character and the deltaTime, giving it the horizontal movement.

        transform.Translate(horizontal, 0, 0); //Changes the horizontal position of the character, based on the calculation above.

        animator.SetBool("Moving", true); //Sets the bool to true on the moving animation, when the player is moving.

    }

    void MoveVertical()
    {
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime; //This gets the vertical axis, multiplies it for the speed of the character and the deltaTime, giving it the vertical movement.

        transform.Translate(0, vertical, 0); //Changes the vertical position of the character, based on the calculation above.

        animator.SetBool("Moving", true); //Sets the bool to true on the moving animation, when the player is moving.
    }

    void PlayerAttack()
    {
         if (Input.GetKeyDown("space")) { //If the player press the space key...
            Instantiate(bullet, blaster.transform.position, Quaternion.identity); //Instantiate a bullet prefab, coming from the previously mentioned invisible box of the gun, for a better looking visual.
            animator.SetBool("pressAtk", true); //Sets the attacking animation to true, to display the animation.
        }

        if (Input.GetKeyUp("space")) {
            animator.SetBool("pressAtk", false); //When the player releases space key, the bool is set to false, cancelling the attack animation and returning to idle or moving.
        }
    }

    void PreventLeavingScreen()
    {
        if(transform.position.x <= -5.7f || transform.position.x >= 5.6f) //If the X position is lower than -5.7 and higher than 5.6...
        {
            float xPos = Mathf.Clamp (transform.position.x, -5.7f, 5.6f); //Clamps the position and stores it in a variable.
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z); //Utilizes the clamped position to lock the player from moving farther than it allows it to.
        }

        if(transform.position.y <= -3.5f || transform.position.y >= 3.9f) //If the Y position is lower than -3.5 and higher than 3.9...
        {
            float yPos = Mathf.Clamp (transform.position.y, -3.5f, 3.9f); //Clamps the position and stores it in a variable.
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z); //Utilizes the clamped position to lock the player from moving farther than it allows it to.
        }
    }

    
    void OnTriggerEnter2D (Collider2D other) //When one of the character colliders activates its trigger...
    {
        if(other.gameObject.tag == "goombaTag" || other.gameObject.tag == "knightTag" || other.gameObject.tag == "motobugTag" ) //Checks if the gameObject contains the goomba tag, the knight tag or the motobug tag.
            {
                die(); //If it contains, it calls the die function, seen below.
            }
    }

    private void takeLives()
    {
        lives = lives - 1; //This takes the actual lives of the character and lowers it by one.
        livesUI.text = "Lives: " + lives; //Refresh the lives text at the screen, with the new lowered value.
    }

    public void die() {
        
        takeLives(); //Calls the function used above, to take one life away.

        if(lives==0)
        {
            Destroy(this.gameObject); //If the player reaches zero lives, it will destroy the character.
            SceneManager.LoadScene("gameover"); //Calls the game over scene, utilized to go to the menu or try again.
        }
    }

}

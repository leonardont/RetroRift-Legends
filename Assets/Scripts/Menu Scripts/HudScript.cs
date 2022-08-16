using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudScript : MonoBehaviour
{
    
    public AudioClip back; //Creates the Audio Clip variable, for the "back" button sound.

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey("escape")) 
        {
            Application.Quit(); //If the player presses ESC, the game quits.
        }
    }

    public void OnClickBackMenu() //When the player clicks the "Menu" button...
    {
        AudioSource.PlayClipAtPoint(back, transform.position); //Plays the back sound.
        DontDestroyOnLoad(back); //Doesn't cancel the audio midway.
        SceneManager.LoadScene("menu"); //Loads the menu scene when the player clicks the back button, as intended.
    }

}

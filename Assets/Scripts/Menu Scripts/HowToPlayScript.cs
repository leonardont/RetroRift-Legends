using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayScript : MonoBehaviour
{
    
    public AudioClip back; //Creates the Audio Clip variable, for the "back" button sound.

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey("escape")) 
        {
            SceneManager.LoadScene("menu"); //Loads the menu scene when the player presses the ESC button, as intended.
        }
    }

    public void OnClickBackMenu()
    {
        AudioSource.PlayClipAtPoint(back, transform.position); //Plays the back sound.
        DontDestroyOnLoad(back); //Doesn't cancel the audio midway.
        SceneManager.LoadScene("menu"); //Loads the menu scene when the player clicks the back button, as intended.
    }

}

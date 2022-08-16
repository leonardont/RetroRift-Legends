using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public AudioClip back; //Creates the Audio Clip variable, for the "back" button sound.
    public AudioClip select; //Creates the Audio Clip variable, for the "select" button sound.

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey("escape")) 
        {
            Application.Quit(); //Quits the game when the player presses the ESC button.
        }
    }

    public void OnClickStartGame()
    {
        AudioSource.PlayClipAtPoint(select, transform.position); //Plays the select sound.
        DontDestroyOnLoad(select); //Doesn't cancel the audio midway.
        SceneManager.LoadScene("fase1"); //Loads the first level.
    }

    public void OnClickHowToPlay()
    {
        AudioSource.PlayClipAtPoint(select, transform.position);
        DontDestroyOnLoad(select);
        SceneManager.LoadScene("howtoplay"); //Loads the how to play screen.
    }

    public void OnClickCredits()
    {
        AudioSource.PlayClipAtPoint(select, transform.position);
        DontDestroyOnLoad(select);
        SceneManager.LoadScene("credits"); //Loads the credits screen.
    }

    public void OnClickExitGame()
    {
        AudioSource.PlayClipAtPoint(back, transform.position); //Plays the back sound.
        DontDestroyOnLoad(back);
        Application.Quit(); //Quits the game when the player presses the back button.
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public AudioClip back; //Creates the Audio Clip variable, for the "back" button sound.
    public AudioClip select; //Creates the Audio Clip variable, for the "select" button sound.

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickBackMenu()
    {
        AudioSource.PlayClipAtPoint(back, transform.position); //Plays the back sound.
        DontDestroyOnLoad(back); //Doesn't cancel the audio midway.
        SceneManager.LoadScene("menu"); //Loads the menu scene when the player clicks the back to menu button, as intended.
    }

    public void OnClickTryAgain()
    {
        AudioSource.PlayClipAtPoint(select, transform.position); //Plays the select sound.
        DontDestroyOnLoad(select);
        SceneManager.LoadScene("fase1"); //Loads the level scene again, for the player to replay it.
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{

    public Text pointsUI; //Creates the points UI variable, utilized in the Unity IDE.
    public Text highscoreUI; //Creates the high score UI variable, utilized in the Unity IDE.

    public int points = 0; //Sets the initial player points value to zero.

    void Start()
    {
        
    }

    void Update()
    {
        if(points > PlayerPrefs.GetInt("HighScore")) //Checks if the player's previously recorded points are bigger or lower than the actual points. If they are lower than the actual points...
        {
            PlayerPrefs.SetInt("HighScore", points); //The new high score is saved regularly by the actual points, if bigger than the previous record.
        }
        
        pointsUI.text = "Points : " + points; //Refreshes the points text at the UI constantly.
        highscoreUI.text = "High Score: " + PlayerPrefs.GetInt("HighScore"); //Refreshes the high score text at the UI constantly.
    }
}

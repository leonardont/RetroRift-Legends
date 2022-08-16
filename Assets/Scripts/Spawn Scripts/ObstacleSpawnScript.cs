using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{

    public GameObject obstMario; //Creates a variable for the obstacle character prefab.
    public GameObject obstSonic; //Creates a variable for the obstacle character prefab.
    public float marioSpawn = 5f; //Creates a definitive spawn time for the obstacle character.
    public float sonicSpawn = 5f; //Creates a definitive spawn time for the obstacle character.

    void Start()
    {
        if(gameObject.tag == ("portalTag1")) //There are two portals in the game, one at the left side and one at the right side.
        {
        InvokeRepeating("addMario", marioSpawn, marioSpawn); //If the portal has the portal tag 1 (left side), it spawns the Mario obstacle, with its spawn time.
        } else if(gameObject.tag == ("portalTag2")){
        InvokeRepeating("addSonic", sonicSpawn, sonicSpawn); //If the portal has the portal tag 2 (right side), it spawns the Sonic obstacle, with its spawn time.
        }
    }

    void Update()
    {
        
    }

    void addMario()
    {
        Renderer renderer = GetComponent<Renderer>(); //Gets the spawn box component.
        var y1 = transform.position.y - renderer.bounds.size.y/2; //Gets the first Y size of the spawn box and limits it, so it doesn't trespass the spawn limits.
        var y2 = transform.position.y + renderer.bounds.size.y/2; //Gets the second Y size of the spawn box and limits it, so it doesn't trespass the spawn limits.

        var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2)); //Sets the limit previously calculated and grabs a random range between this limit, to randomly spawn these characters each time.

        Instantiate(obstMario, spawnPoint, Quaternion.identity); //Instantiate the character prefab together with is random spawn point.
    }

    void addSonic()
    {
        Renderer renderer = GetComponent<Renderer>();
        var y1 = transform.position.y - renderer.bounds.size.y/2;
        var y2 = transform.position.y + renderer.bounds.size.y/2;

        var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2)); 

        Instantiate(obstSonic, spawnPoint, transform.rotation * Quaternion.Euler (0, 180, 0)); //Instantiate the character prefab together with is random spawn point, but with a 180 rotation, to properly display its sprite going to the left side.
    }

}
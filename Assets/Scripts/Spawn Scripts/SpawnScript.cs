using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject enemyGoomba; //Creates the variable for the enemy prefab.
    public GameObject enemyKnight;
    public GameObject enemyMotobug;
    public float goombaSpawn = 4f; //Creates the spawn time for the enemy.
    public float knightSpawn = 7f;
    public float motobugSpawn = 5f;

    void Start()
    {
        InvokeRepeating("addGoomba", goombaSpawn, goombaSpawn); //Creates the invoke and repeat for the enemy (functions below), together with its spawn time.
        InvokeRepeating("addKnight", knightSpawn, knightSpawn);
        InvokeRepeating("addMotobug", motobugSpawn, motobugSpawn);
    }

    void Update()
    {
        
    }

    void addGoomba()
    {
        Renderer renderer = GetComponent<Renderer>(); //Gets the spawn box component.
        var x1 = transform.position.x - renderer.bounds.size.x/2; //Gets the first X size of the spawn box and limits it, so it doesn't trespass the spawn limits.
        var x2 = transform.position.x + renderer.bounds.size.x/2; //Gets the second X size of the spawn box and limits it, so it doesn't trespass the spawn limits.

        var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y); //Sets the limit previously calculated and grabs a random range between this limit, to randomly spawn these characters each time.

        Instantiate(enemyGoomba, spawnPoint, Quaternion.identity); //Instantiate the character prefab together with is random spawn point.
    }

    void addKnight()
    {
        Renderer renderer = GetComponent<Renderer>();
        var x1 = transform.position.x - renderer.bounds.size.x/2;
        var x2 = transform.position.x + renderer.bounds.size.x/2;

        var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(enemyKnight, spawnPoint, Quaternion.identity);
    }

    void addMotobug()
    {
        Renderer renderer = GetComponent<Renderer>();
        var x1 = transform.position.x - renderer.bounds.size.x/2;
        var x2 = transform.position.x + renderer.bounds.size.x/2;

        var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(enemyMotobug, spawnPoint, Quaternion.identity);
    }

}

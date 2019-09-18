using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemy;                // The enemy prefab to be spawned.
    public float spawnInterval;
    [SerializeField]
    private float spawnTime;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    GameObject player;


    void Start()
    {
        spawnTime = spawnInterval;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        spawnTime -= Time.deltaTime;
        if (player != null)
        {

            if(spawnTime <= 0)
            {
                Spawn();
                spawnTime = spawnInterval;
                Debug.Log("spawn enemies");
            }
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
          //  InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }

    void Spawn()
    {
      

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemy.Length);


        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        //Instantiate(enemy[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        //  Instantiate(enemy[1], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        Instantiate(enemy[enemyIndex], spawnPoints[0].position, spawnPoints[0].rotation);
        Instantiate(enemy[enemyIndex], spawnPoints[1].position, spawnPoints[1].rotation);
        Instantiate(enemy[enemyIndex], spawnPoints[2].position, spawnPoints[2].rotation);
      //  Instantiate(enemy[enemyIndex], spawnPoints[3].position, spawnPoints[3].rotation);



    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    //set array to store prefab of star
    public GameObject[] star;
    private int starNumber;
    
    //set maxSpawnTime and spawnPerTime
    public int maxSpawn;
    public int[] spawnTime;
    private int spawnTimesReal;

    public void starSpawn()
    {
        //get random number of time for spawn
        spawnTimesReal = Random.Range(spawnTime[0], spawnTime[1]); 
        
        //spawn
        if (maxSpawn > 0)
        {
            for (int i = 0; i <= spawnTimesReal ; i++)
            {
               starNumber = Random.Range(0, star.Length);
               Instantiate(star[starNumber]);
            }
            maxSpawn -= 1;
        }
    }
}

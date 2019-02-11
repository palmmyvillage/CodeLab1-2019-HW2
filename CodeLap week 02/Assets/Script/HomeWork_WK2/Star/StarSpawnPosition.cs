using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawnPosition : MonoBehaviour
{
    //set variable for starSpawnPosition
    public float xOrigin_min;
    public float xOrigin_max;
    public float yOrigin_min;
    public float yOrigin_max;
    public float zOrigin_min;
    public float zOrigin_max;
    
    //set variable for random
    private float xOrigin;
    private float yOrigin;
    private float zOrigin;
    
    // Start is called before the first frame update
    void Awake()
    {
        //calculate random
        xOrigin = Random.Range(xOrigin_min, xOrigin_max);
        yOrigin = Random.Range(yOrigin_min, yOrigin_max);
        zOrigin = Random.Range(zOrigin_min, zOrigin_max);
        
        //set position of Star
        transform.position = new Vector3(xOrigin,yOrigin,zOrigin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

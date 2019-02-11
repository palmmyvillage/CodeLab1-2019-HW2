using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CirclingMotion : MonoBehaviour
{
    private float timeControl; //set time to use as multiplier for circle movement

    // set variable for storing center co-ordinates
    private float xOrigin;
    private float yOrigin;
    private float zOrigin;

    //set public speed of circling
    public float circlingSpeed;
    
    //set public scaler for circling size
    //set negative to make it circling backward
    //set it 0 to not let it circling in such axis
    private float x_scaler;
    private float y_scaler;
    private float z_scaler;
    
    //for random, use same number for min-max to make it constant
    public float x_scaler_min;
    public float x_scaler_max;
    public float y_scaler_min;
    public float y_scaler_max;
    public float z_scaler_min;
    public float z_scaler_max;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //initiate the center of circling
        xOrigin = transform.position.x;
        yOrigin = transform.position.y;
        zOrigin = transform.position.z;
        
        //random scaler
        x_scaler = Random.Range(x_scaler_min, x_scaler_max);
        y_scaler = Random.Range(y_scaler_min, y_scaler_max);
        z_scaler = Random.Range(z_scaler_min, z_scaler_max);
    }

    // Update is called once per frame
    void Update()
    {
        //calculate speed for circling
        timeControl += Time.deltaTime * circlingSpeed;

        //calculate circling movement
        float x = xOrigin + Mathf.Cos(timeControl) * x_scaler;
        float y = yOrigin + Mathf.Sin(timeControl) * y_scaler;
        float z = zOrigin + Mathf.Cos(timeControl) * z_scaler;
        
        //make the position move in circle
        transform.position = new Vector3(x,y,z);
    }
}

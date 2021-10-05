using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotation : MonoBehaviour
{
    public int xdirection;
    public int ydirection;
    public int zdirection;

    private int xRotation;
    private int yRotation;
    private int zRotation;


    // Start is called before the first frame update
    void Start()
    {
        xRotation = Random.Range(0, xdirection);
        yRotation = Random.Range(0, ydirection);
        zRotation = Random.Range(0, zdirection);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0, yRotation, 0) * Time.deltaTime);
    }
}

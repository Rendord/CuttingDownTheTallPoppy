using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.SearchService;
using UnityEngine;

public class RotateAroundScene : MonoBehaviour
{

    public float rotationSpeed = 0.03f;
    public Vector3 origin = Vector3.zero;
    public Vector3 rotationAxis = new Vector3(0,0,1);
    // Start is called before the first frame update
    void Start()
    {
        //transform.LookAt(origin);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(origin, rotationAxis, -rotationSpeed * Time.deltaTime * 1000);
        //transform.LookAt(origin);
        //transform.Rotate(-0.030f * Time.deltaTime * 1000, 0, 0);
    }
}

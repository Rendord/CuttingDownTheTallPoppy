using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTheCar : MonoBehaviour
{
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Time.deltaTime * speed, 0, 0);
        transform.position -= movement; 
    }
}

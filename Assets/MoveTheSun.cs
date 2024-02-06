using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheSun : MonoBehaviour
{
    public float clock = 0.0f;
    public bool stopTime = true;

    // Start is called before the first frame update
    void Start()
    {
        StartTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTime == false)
        {
            clock += Time.deltaTime;
            Debug.Log(Time.deltaTime);
            gameObject.transform.Rotate(0.030f * Time.deltaTime * 1000, 0, 0);
            Debug.Log(gameObject.transform.eulerAngles.x);
            if (clock > 12.0f)
            {
                clock -= 12.0f;
                //gameObject.transform.eulerAngles = new Vector3(
                //    gameObject.transform.eulerAngles.x - 360f,
                //    gameObject.transform.eulerAngles.y,
                //    gameObject.transform.eulerAngles.z
                    

            }
        }
    }

    public void StartTime()
    {
        stopTime = false;
    }

    public void StopTime()
    {
        stopTime = true;
    }

    public void ResetTime()
    {
        clock = 0.0f;
    }
}

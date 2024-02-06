using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Impact : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        Debug.Log(name);
        if (name == "Spring" || name == "Summer" || name == "Fall" || name == "Winter")
        {
            if (collision.gameObject.TryGetComponent(out Renderer m))
            {
                AffectTheSpatialRift.m_SeasonalDrift.Invoke(m.material);
            }
        }
        
    }
}

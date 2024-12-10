using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 20;
    private float lowerBound = -37;
    private float leftBound = -45;
    private float rightBound = 45;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < lowerBound)
        {
            Destroy(gameObject);
        }

        else if (transform.position.z < leftBound)
        {
            Destroy(gameObject);
        }

        else if (transform.transform.position.z > rightBound)
        {
            Destroy(gameObject);
        }
    }
}

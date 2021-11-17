using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCounter : MonoBehaviour
{
    int counter = 0;

    // Update is called once per frame
    void Update()
    {
        if (counter > 10)
        {
            Debug.Log(counter);
            //// Aj von
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CubeTag"))
        {
            counter++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CubeTag"))
        {
            counter--;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCounter : MonoBehaviour
{
    int counter = 0;
    bool Win = false;

    public GameObject Crystal;

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (counter > 10 && !Win)
        {
            Win = true;
            Crystal.SetActive(true);

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

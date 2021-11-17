using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallsCounter : MonoBehaviour
{
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 750)
        {
            Debug.Log(counter);
            //// Aj von
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterBallTag"))
        {
            counter++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WaterBallTag"))
        {
            counter--;
        }
    }
}

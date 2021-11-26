using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallsCounter : MonoBehaviour
{
    int counter = 0;

    private int NumberOfWaterballsWin = 750;
    
    private bool Win = false;
    public bool HoldsBucket = true;
    public GameObject Bucket;
    private Vector3 BucketStartPosition;

    public GameObject Crystal;

    // Start is called before the first frame update
    void Start()
    {
        BucketStartPosition = Bucket.transform.position;
    }

    // Update is called once per frame
    void Update()
    {   if (counter > NumberOfWaterballsWin && !Win)
            {
                Win = true;
                Crystal.SetActive(true);
                HoldsBucket = false;
                Bucket.transform.position = BucketStartPosition;
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

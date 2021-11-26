using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathtubBucketRotator : MonoBehaviour
{
    public GameObject Bucket;
    Rigidbody BucketRigidbody;
    bool NearBathtub = false;
    Quaternion start_rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    Quaternion end_rotation = Quaternion.Euler(new Vector3(0, 0, 99));
    Quaternion lintz = Quaternion.Euler(new Vector3(0, 0, 3));
    Quaternion i_lintz = Quaternion.Euler(new Vector3(0, 0, -3));

   
    // Start is called before the first frame update
    void Start()
    {

        BucketRigidbody = Bucket.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NearBathtub && GetComponent<BucketHolder>().HoldsBucket)
        {
            if (BucketRigidbody.rotation != end_rotation)
            {
                BucketRigidbody.MoveRotation(BucketRigidbody.rotation * lintz);
            }

        }
        else
        {
            if (BucketRigidbody.rotation != start_rotation)
            {
                BucketRigidbody.MoveRotation(BucketRigidbody.rotation * i_lintz);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BathtubTag"))
        {
            
            NearBathtub = true;

        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BathtubTag"))
        {
           
            NearBathtub = false;

        }
    }
}

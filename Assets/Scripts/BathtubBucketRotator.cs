using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathtubBucketRotator : MonoBehaviour
{
    public GameObject Bucket;
    Rigidbody BucketRigidbody;
    Vector3 m_EulerAngleVelocity = new Vector3(0, 0, 90);
    // Start is called before the first frame update
    void Start()
    {

        BucketRigidbody = Bucket.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BathtubTag"))
        {
            Debug.Log("hitvane");
            // nefunguje, neviem preco
            // mozno to treba cele fixnut do nejakej pozicie alebo co
            Bucket.transform.rotation = Quaternion.Euler(new Vector3(Bucket.transform.rotation.x + 90, Bucket.transform.rotation.y, Bucket.transform.rotation.z));
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
            BucketRigidbody.MoveRotation(BucketRigidbody.rotation * deltaRotation);

        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BathtubTag"))
        {
            Bucket.transform.rotation = Quaternion.Euler(new Vector3(Bucket.transform.rotation.x - 90, Bucket.transform.rotation.y, Bucket.transform.rotation.z));
            //tiez nefunguje
            Quaternion deltaRotation = Quaternion.Euler(-m_EulerAngleVelocity * Time.fixedDeltaTime);
            BucketRigidbody.MoveRotation(BucketRigidbody.rotation * deltaRotation);

        }
    }
}

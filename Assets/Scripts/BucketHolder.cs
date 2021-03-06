using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketHolder : MonoBehaviour
{
    public bool HoldsBucket = false;
    private bool InsideArchimedesRoom;
    public GameObject Bucket;
    private float BucketPositionMultiplyer;
    private Vector3 BucketStartPosition;

    public GameObject Sphere2;
    public GameObject BathtubFilledTester;


    // Start is called before the first frame update
    void Start()
    {
        BucketStartPosition = Bucket.transform.position;
        BucketPositionMultiplyer = Bucket.GetComponent<BucketMover>().BucketPositionMultiplyer;
    }

    // Update is called once per frame
    void Update()
    {
        InsideArchimedesRoom = GetComponent<PlayerInRoomController>().IsInArchimedesRoom;
        if (!BathtubFilledTester.GetComponent<WaterBallsCounter>().HoldsBucket)
        {
            HoldsBucket = false;
        }

        if (HoldsBucket && !InsideArchimedesRoom)
        {
            Bucket.transform.position = BucketStartPosition;
            HoldsBucket = false;
        }
    }   


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BucketHolder") && InsideArchimedesRoom)
        {
           if (!HoldsBucket && BathtubFilledTester.GetComponent<WaterBallsCounter>().HoldsBucket)
            {
                HoldsBucket = true;
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
                Bucket.transform.position = new Vector3(transform.position.x + BucketPositionMultiplyer * ray.direction.x,
                                                        transform.position.y - 0.5f + BucketPositionMultiplyer * ray.direction.y,
                                                        transform.position.z + BucketPositionMultiplyer * ray.direction.z);


            }
            else
            {
                HoldsBucket = false;
                Bucket.transform.position = BucketStartPosition;
                
            }
        }
    }
}

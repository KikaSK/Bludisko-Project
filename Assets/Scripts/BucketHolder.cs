using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketHolder : MonoBehaviour
{
    public bool HoldsBucket = false;
    private bool InsideArchimedesRoom;
    public GameObject Bucket;
    private float BucketPositionMultiplyer = 1.0f;
    private Vector3 BucketStartPosition;
    private float ScreenWidth;
    private float ScreenHeight;

    public GameObject Sphere1;
    public GameObject Sphere2;


    // Start is called before the first frame update
    void Start()
    {
        BucketStartPosition = Bucket.transform.position;
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        InsideArchimedesRoom = GetComponent<PlayerInRoomController>().IsInArchimedesRoom;
        /*
         * if (InsideArchimedesRoom)
        {

        }
        */
        // 

        /*if (HoldsBucket) // if holds the bucket we change the position of bucket
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(ScreenWidth/2,ScreenHeight/2));

            Bucket.transform.position = new Vector3(transform.position.x + BucketPositionMultiplyer * ray.direction.x,
                                                    transform.position.y - 0.5f + BucketPositionMultiplyer * ray.direction.y,
                                                    transform.position.z + BucketPositionMultiplyer * ray.direction.z);

            //netreba tu kdesi time delta time???

        }
        */
    }   


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BucketHolder") && InsideArchimedesRoom)
        {
           if (!HoldsBucket)
            {
                HoldsBucket = true;
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(ScreenWidth / 2, ScreenHeight / 2));
                Bucket.transform.position = new Vector3(transform.position.x + BucketPositionMultiplyer * ray.direction.x,
                                                        transform.position.y - 0.5f + BucketPositionMultiplyer * ray.direction.y,
                                                        transform.position.z + BucketPositionMultiplyer * ray.direction.z);

                /*
                 * Sphere1.transform.position = new Vector3(Bucket.transform.position.x,
                                                         Bucket.transform.position.y + 0.5f,
                                                         Bucket.transform.position.z);
                */

            }
            else
            {
                HoldsBucket = false;
                Bucket.transform.position = BucketStartPosition;
                
            }
        }
    }
}

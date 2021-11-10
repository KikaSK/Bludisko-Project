using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketMover : MonoBehaviour
{
    bool HoldsBucketMover;
    //public GameObject BucketHolder;
    public GameObject Player;
    bool InsideArchimedesRoom;

    Rigidbody BucketRigidbody;
    public float BucketSpeed = 5f;

    private float ScreenWidth;
    private float ScreenHeight;

    private float BucketPositionMultiplyer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        BucketRigidbody = GetComponent<Rigidbody>();
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HoldsBucketMover = Player.GetComponent<BucketHolder>().HoldsBucket;
        
        InsideArchimedesRoom = Player.GetComponent<PlayerInRoomController>().IsInArchimedesRoom;
        if (HoldsBucketMover && InsideArchimedesRoom)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(ScreenWidth / 2, ScreenHeight / 2));

            Vector3 CurrPosition = transform.position;
            Vector3 NewPosition = new Vector3(ray.origin.x + BucketPositionMultiplyer * ray.direction.x,
                                                            ray.origin.y - 0.5f + BucketPositionMultiplyer * ray.direction.y ,
                                                            ray.origin.z + BucketPositionMultiplyer * ray.direction.z );

            Vector3 MovementVector = NewPosition - CurrPosition;
            BucketRigidbody.MovePosition(transform.position + MovementVector * Time.fixedDeltaTime * BucketSpeed);
            //BucketRigidbody.position = NewPosition;
           
        }
    }
}

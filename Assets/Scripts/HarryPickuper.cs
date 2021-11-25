using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarryPickuper : MonoBehaviour
{
    private bool IsPicked;
    private int PickedCounter;

    private GameObject PickedObject;
    private Vector3 StartPos;

    private float ScreenWidth;
    private float ScreenHeight;

    // Start is called before the first frame update
    void Start()
    {
        IsPicked = false;
        PickedCounter = 0;

        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerInRoomController>().IsInHarryRoom  && IsPicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(ScreenWidth / 2, ScreenHeight / 2));

            PickedObject.transform.position = new Vector3(transform.position.x + 2.0f * ray.direction.x,
                                                   transform.position.y + 2.0f * ray.direction.y,
                                                   transform.position.z + 2.0f * ray.direction.z);
        }
        if (!GetComponent<PlayerInRoomController>().IsInHarryRoom && IsPicked)
        {
            PickedObject.transform.position = StartPos;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<PlayerInRoomController>().IsInHarryRoom)
        {
            if (!IsPicked)
            {
                if (other.CompareTag("HarryPickuble"))
                {
                    PickedObject = other.gameObject;
                    StartPos = PickedObject.transform.position;
                    Ray ray = Camera.main.ScreenPointToRay(new Vector2(ScreenWidth / 2, ScreenHeight / 2));

                    PickedObject.transform.position = new Vector3(transform.position.x + 2.0f * ray.direction.x,
                                                           transform.position.y + 2.0f * ray.direction.y,
                                                           transform.position.z + 2.0f * ray.direction.z);
                    IsPicked = true;
                }
            }
            else
            {
                if (other.CompareTag("PickubleRecieverTag"))
                {
                    PickedCounter++;
                    Destroy(PickedObject);
                    IsPicked = false;
                }
            }
        }
    }
}

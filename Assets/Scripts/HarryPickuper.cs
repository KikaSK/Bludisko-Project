using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarryPickuper : MonoBehaviour
{
    private bool IsPicked;
    private int PickedCounter;

    private GameObject PickedObject;

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
        if(IsPicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(ScreenWidth / 2, ScreenHeight / 2));

            PickedObject.transform.position = new Vector3(transform.position.x + 2.0f * ray.direction.x,
                                                   transform.position.y + 2.0f * ray.direction.y,
                                                   transform.position.z + 2.0f * ray.direction.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!IsPicked)
        {
            if (other.CompareTag("HarryPickuble"))
            {
                PickedObject = other.gameObject;
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

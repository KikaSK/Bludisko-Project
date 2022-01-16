using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    Vector3 P1 = new Vector3(-61.4f, 2.5f, 9.61f);
    Vector3 P2 = new Vector3(-36.1f, 2.5f, 21.2f);
    Vector3 P3 = new Vector3(48.9f, 2.5f, 9.9f);
    Vector3 P4 = new Vector3(56.8f, 2.5f, -26.4f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }




    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PortalTag1"))
        {
            transform.parent.transform.position = P3;
        }
        else if (other.CompareTag("PortalTag2"))
        {
            transform.parent.transform.position = P4;
        }
        else if (other.CompareTag("PortalTag3"))
        {
            transform.parent.transform.position = P1;
            
        }
        else if (other.CompareTag("PortalTag4"))
        {
            transform.parent.transform.position = P2;
        }
    }
}

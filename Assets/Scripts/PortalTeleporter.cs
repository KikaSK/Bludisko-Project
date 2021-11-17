using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    Vector3 P1 = new Vector3(-61.4f, 2.5f, 9.61f);
    Vector3 P2 = new Vector3(-37.6f, 2.5f, 9.23f);
    Vector3 P3 = new Vector3(48.9f, 2.5f, 36.0f);
    Vector3 P4 = new Vector3(56.8f, 2.5f, -26.4f);

    Quaternion R1_3 = Quaternion.Euler(new Vector3(0, 180, 0));
    Quaternion R4 = Quaternion.Euler(new Vector3(0, 90, 0));

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
            transform.position = P3;
            transform.rotation = R1_3;
        }
        else if (other.CompareTag("PortalTag2"))
        {
            transform.position = P4;
            transform.rotation = R4;
        }
        else if (other.CompareTag("PortalTag3"))
        {
            transform.position = P1;
            transform.rotation = R1_3;
        }
        else if (other.CompareTag("PortalTag4"))
        {
            transform.position = P2;
            transform.rotation = R1_3;
        }
    }
}

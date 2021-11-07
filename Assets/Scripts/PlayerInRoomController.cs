using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoomController : MonoBehaviour
{
    public bool IsInPyramidsRoom;
    public bool IsInHarryRoom;
    public bool IsInArchimedesRoom;

    private GameObject PyramidsSphere;
    private GameObject ArchimedesSphere;


    // Start is called before the first frame update
    void Start()
    {
        PyramidsSphere = GameObject.Find("PyramidsSphere");
        ArchimedesSphere = GameObject.Find("ArchimedesSphere");
    }

    // Update is called once per frame
    void Update()
    {
        //pyramids room control
        if (transform.position.x > 56.0 &&
            transform.position.z < -30.5 &&
            transform.position.x < 91.0 &&
            transform.position.z > -68.0)
        {
            IsInPyramidsRoom = true;
            PyramidsSphere.SetActive(true);

        }
        else
        {
            IsInPyramidsRoom = false;
            PyramidsSphere.SetActive(false);
        }

        //harry room control
        if (transform.position.x > 8.0 &&
            transform.position.z < 33.0 &&
            transform.position.x < 37.2 &&
            transform.position.z > 9.2)
        {
            IsInHarryRoom = true;

        }
        else
        {
            IsInHarryRoom = false;
        }

        //Archimedes room control
        if (transform.position.x > -63.6 &&
            transform.position.z < 98.0 &&
            transform.position.x < -33.5 &&
            transform.position.z > 66.9)
        {
            IsInArchimedesRoom = true;
            ArchimedesSphere.SetActive(true);

        }
        else
        {
            IsInArchimedesRoom = false;
            ArchimedesSphere.SetActive(false);
        }
    }
}

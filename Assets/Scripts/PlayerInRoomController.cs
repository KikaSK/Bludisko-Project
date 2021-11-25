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



        if (transform.position.x > 54.71 &&
            transform.position.z < -30.5 &&
            transform.position.x < 91.0 &&
            transform.position.z > -68.0)
        {
            
            PyramidsSphere.SetActive(true);

        }
        else
        {
            PyramidsSphere.SetActive(false);
        }
        
        if (transform.position.x > 59.85 &&
            transform.position.z < -30.5 &&
            transform.position.x < 91.0 &&
            transform.position.z > -68.0)
        {
            IsInPyramidsRoom = true;
        }
        else
        {
            IsInPyramidsRoom = false;
            
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
        if (transform.position.x > -62.67 &&
            transform.position.z < 98.0 &&
            transform.position.x < -33.5 &&
            transform.position.z > 67.59)
        {
            IsInArchimedesRoom = true;
        }
        else
        {
            IsInArchimedesRoom = false;
        }

        if (transform.position.x > -71.6 &&
            transform.position.z < 98.0 &&
            transform.position.x < -33.5 &&
            transform.position.z > 61.48)
        {
            ArchimedesSphere.SetActive(true);
        }
        else
        {
            ArchimedesSphere.SetActive(false);
        }
    }
}

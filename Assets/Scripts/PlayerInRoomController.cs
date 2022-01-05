using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoomController : MonoBehaviour
{
    public bool IsInPyramidsRoom;
    public bool IsInHarryRoom;
    public bool IsInArchimedesRoom;
    public bool IsInSpaceRoom1;
    public bool IsInEarthRoom;

    private GameObject PyramidsSphere;
    private GameObject ArchimedesSphere;
    private GameObject Space1Sphere;
    private GameObject EarthSphere;

    public GameObject ObjectsCountHarry;

    // Start is called before the first frame update
    void Start()
    {
        PyramidsSphere = GameObject.Find("PyramidsSphere");
        ArchimedesSphere = GameObject.Find("ArchimedesSphere");
        Space1Sphere = GameObject.Find("SpaceSphere1");
        EarthSphere = GameObject.Find("EarthSphere");
        ObjectsCountHarry.SetActive(false);
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

            ObjectsCountHarry.SetActive(true);
            IsInHarryRoom = true;

        }
        else
        {
            ObjectsCountHarry.SetActive(false);
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

        //Space1 room control
        if (transform.position.x > 59.93 &&
            transform.position.z < 90.0 &&
            transform.position.x < 83.0 &&
            transform.position.z > 67.58)
        {
            IsInSpaceRoom1 = true;
        }
        else
        {
            IsInSpaceRoom1 = false;
        }

        if (transform.position.x > 57.70 &&
            transform.position.z < 90.0 &&
            transform.position.x < 83.0 &&
            transform.position.z > 65.0)
        {
            Space1Sphere.SetActive(true);
        }
        else
        {
            Space1Sphere.SetActive(false);
        }

        //Earth room control
        if (transform.position.x > -71.46 &&
            transform.position.z < -0.06 &&
            transform.position.x < -51.6 &&
            transform.position.z > -34.21)
        {
            IsInEarthRoom = true;
        }
        else
        {
            IsInEarthRoom = false;
        }

        if (transform.position.x > -74.88 &&
            transform.position.z < 0.06 &&
            transform.position.x < -47.31 &&
            transform.position.z > -34.21)
        {
            EarthSphere.SetActive(true);
        }
        else
        {
            EarthSphere.SetActive(false);
        }
    }
}

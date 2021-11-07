using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidsBuilder : MonoBehaviour
{
    public GameObject cube;
    public int Distance = 5;
    public float MaxDistance = 15.0f;
    private bool InsidePyramidsRoom;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InsidePyramidsRoom = GetComponent<PlayerInRoomController>().IsInPyramidsRoom;
        if (InsidePyramidsRoom)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool is_hit = Physics.Raycast(ray.origin, ray.direction, out hit);

                double x = ray.direction.x;
                double y = ray.direction.y;
                double z = ray.direction.z;

                double cosine = Mathf.Sqrt((float)((x * x + z * z) / (x * x + y * y + z * z)));
                float dist = Mathf.Min((float)(Distance / (cosine + 0.001)), MaxDistance);
                //float dist = (float)Distance;

                Vector3 new_cube_point;
                if (is_hit)
                {
                    double hit_dist = (hit.point.x - ray.origin.x) * (hit.point.x - ray.origin.x) +
                                      (hit.point.y - ray.origin.y) * (hit.point.y - ray.origin.y) +
                                      (hit.point.z - ray.origin.z) * (hit.point.z - ray.origin.z);
                    if (hit_dist < dist * dist)
                    {
                        new_cube_point = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    }
                    else
                    {
                        new_cube_point = new Vector3(ray.origin.x + dist * ray.direction.x, ray.origin.y + dist * ray.direction.y, ray.origin.z + dist * ray.direction.z);
                    }
                }
                else
                {
                    new_cube_point = new Vector3(ray.origin.x + dist * ray.direction.x, ray.origin.y + dist * ray.direction.y, ray.origin.z + dist * ray.direction.z);
                }


                GameObject new_object = Instantiate(cube, transform.parent);
                new_object.transform.position = new_cube_point;

            }
        }
    }
}

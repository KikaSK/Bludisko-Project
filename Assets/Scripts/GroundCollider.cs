using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    private int SizeOfList = 1000;
    List<KeyValuePair<float, GameObject>> CollidedSpheres = new List<KeyValuePair<float, GameObject>>();
    int iter = 0;
    int additer = 0;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(CollidedSpheres.Count>iter && (Time.time - CollidedSpheres[iter].Key) > 2)
        {
            Destroy(CollidedSpheres[iter].Value);
            //CollidedSpheres[iter].Value.SetActive(false);
            iter = (iter+1)%SizeOfList;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WaterBallTag"))
        {
            if (counter < SizeOfList)
            {
                CollidedSpheres.Add(new KeyValuePair<float, GameObject>(Time.time, other.gameObject));
                counter++;
            }
            else
            {
                CollidedSpheres[additer] = (new KeyValuePair<float, GameObject>(Time.time, other.gameObject));
                additer = (additer + 1) % SizeOfList;
            }
        }
    }
}

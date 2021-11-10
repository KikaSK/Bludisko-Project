using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCreator : MonoBehaviour
{

    bool InsideArchimedesRoom;
    List<GameObject> spheres = new List<GameObject>();
    int iter = 0;
    public GameObject SpheresParent;
    public float WaterFlow;
    public GameObject WaterBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        WaterFlow = 3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InsideArchimedesRoom = GetComponent<PlayerInRoomController>().IsInArchimedesRoom;
        if(InsideArchimedesRoom)
        {
            iter++;
            if(iter > 5.0f/WaterFlow)
            {
                iter = 0;
                //Debug.Log("insideargimedes" + iter.ToString());
                GameObject sphere = GameObject.Instantiate(WaterBallPrefab, 
                    new Vector3(-42.56798f - 6.695f, -1.576401f + 3.874f+ 0.7f, 71.9314f + 5.44f), // position
                    new Quaternion(0f, 0f, 0f, 0f)); // rotation

                spheres.Add(sphere);
                spheres[spheres.Count - 1].transform.parent = SpheresParent.transform;
            }
        }
    }
}

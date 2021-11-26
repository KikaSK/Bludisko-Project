using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchimedesRoomWinner : MonoBehaviour
{

    public GameObject Crystal;
    private float? CrystalTriggerTime = null;

    // Start is called before the first frame update
    void Start()
    {
        Crystal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CrystalTriggerTime.HasValue && Time.time - CrystalTriggerTime.Value > 3.5f)
        {
            Crystal.SetActive(false);
            CrystalTriggerTime = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<PlayerInRoomController>().IsInArchimedesRoom)
        {
            if (other.CompareTag("CrystalTag"))
            {
                Crystal.GetComponent<Animator>().SetTrigger("Trigger");
                CrystalTriggerTime = Time.time;

            }
        }
    }
}

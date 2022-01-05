using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidsRoomWinner : MonoBehaviour
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
            GetComponent<CrystalsPickuper>().crystalcount++;
            GetComponent<CrystalsPickuper>().CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = GetComponent<CrystalsPickuper>().crystalcount.ToString() + "/10";
            GetComponent<CameraController>().WinPyramids = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (GetComponent<PlayerInRoomController>().IsInPyramidsRoom)
        {
            if (other.CompareTag("CrystalTag"))
            {
                Crystal.GetComponent<Animator>().SetTrigger("Trigger");
                CrystalTriggerTime = Time.time;
            }
        }
    }
}

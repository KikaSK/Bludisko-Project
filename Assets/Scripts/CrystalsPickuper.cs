using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsPickuper : MonoBehaviour
{

    public GameObject CrystalSpace1;
    private float? CrystalSpace1TriggerTime = null;

    public GameObject CrystalEarth;
    private float? CrystalEarthTriggerTime = null;

    public GameObject Crystal1;
    public GameObject Crystal2;
    public GameObject Crystal3;
    public GameObject Crystal4;
    public GameObject Crystal5;

    public int crystalcount = 0;
    public GameObject CrystalCountText;

    // Start is called before the first frame update
    void Start()
    {
        CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = "0/10";
    }

    // Update is called once per frame
    void Update()
    {
        if (CrystalSpace1TriggerTime.HasValue && Time.time - CrystalSpace1TriggerTime.Value > 2.5f)
        {
            CrystalSpace1.SetActive(false);
            CrystalSpace1TriggerTime = null;
            crystalcount++;
            CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = crystalcount.ToString() + "/10";
        }

        if (CrystalEarthTriggerTime.HasValue && Time.time - CrystalEarthTriggerTime.Value > 2.5f)
        {
            CrystalEarth.SetActive(false);
            CrystalEarthTriggerTime = null;
            crystalcount++;
            CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = crystalcount.ToString() + "/10";
        }
        if(crystalcount == 10)
        {
            GetComponent<CameraController>().Paper5.SetActive(true);
            GetComponent<CameraController>().MenuOpen = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CrystalTag"))
        {
            if (GetComponent<PlayerInRoomController>().IsInSpaceRoom1)
            {
                CrystalSpace1.GetComponent<Animator>().SetTrigger("Trigger");
                CrystalSpace1TriggerTime = Time.time;
            }
            if (GetComponent<PlayerInRoomController>().IsInEarthRoom)
            {
                CrystalEarth.GetComponent<Animator>().SetTrigger("Trigger");
                CrystalEarthTriggerTime = Time.time;
            }
            if(other.name == "Crystal1")
            {
                Crystal1.SetActive(false);
                crystalcount++;
                CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = crystalcount.ToString() + "/10";
            }
            if (other.name == "Crystal2")
            {
                Crystal2.SetActive(false);
                crystalcount++;
                CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = crystalcount.ToString() + "/10";
            }
            if (other.name == "Crystal3")
            {
                Crystal3.SetActive(false);
                crystalcount++;
                CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = crystalcount.ToString() + "/10";
            }
            if (other.name == "Crystal4")
            {
                Crystal4.SetActive(false);
                crystalcount++;
                CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = crystalcount.ToString() + "/10";
            }
            if (other.name == "Crystal5")
            {
                Crystal5.SetActive(false);
                crystalcount++;
                CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = crystalcount.ToString() + "/10";
            }
        }

    }
}

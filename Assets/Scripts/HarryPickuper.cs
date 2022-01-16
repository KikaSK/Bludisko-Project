using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarryPickuper : MonoBehaviour
{
    private bool IsPicked;
    private int PickedCounter;
    public GameObject ObjectsCountText;

    private GameObject PickedObject;
    private Vector3 StartPos;

    private bool Win = false;

    private int NumberOfPickuble = 10;

    public GameObject Crystal;
    private float? CrystalTriggerTime = null;

    // Start is called before the first frame update
    void Start()
    {
        IsPicked = false;
        PickedCounter = 0;

        Crystal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerInRoomController>().IsInHarryRoom  && IsPicked)
        {
            PickedObject.transform.position = transform.parent.transform.position + 2.0f * Camera.main.transform.forward;
        }
        if (!GetComponent<PlayerInRoomController>().IsInHarryRoom && IsPicked)
        {
            PickedObject.transform.position = StartPos;
            IsPicked = false;
        }
        if (CrystalTriggerTime.HasValue && Time.time - CrystalTriggerTime.Value  > 2.5f)
        {
            Crystal.SetActive(false);
            CrystalTriggerTime = null; 
            GetComponent<CrystalsPickuper>().crystalcount++;
            GetComponent<CrystalsPickuper>().CrystalCountText.GetComponent<TMPro.TextMeshProUGUI>().text = GetComponent<CrystalsPickuper>().crystalcount.ToString() + "/10";
            GetComponent<CameraController>().WinHarry = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<PlayerInRoomController>().IsInHarryRoom)
        {
            if (!IsPicked)
            {
                if (other.CompareTag("HarryPickuble"))
                {
                    PickedObject = other.gameObject;
                    StartPos = PickedObject.transform.position;

                    PickedObject.transform.position = transform.parent.transform.position + 2.0f * Camera.main.transform.forward;

                    IsPicked = true;
                }
            }
            else
            {
                if (other.CompareTag("PickubleRecieverTag"))
                {
                    PickedCounter++;
                    ObjectsCountText.GetComponent<TMPro.TextMeshProUGUI>().text = PickedCounter.ToString() + "/10";
                    Destroy(PickedObject);
                    IsPicked = false;
                    if(PickedCounter == NumberOfPickuble && !Win)
                    {
                        Win = true;
                        WinTrigger();
                    }
                }
            }

            if(other.CompareTag("CrystalTag"))
            {
                Crystal.GetComponent<Animator>().SetTrigger("PlayerTrigger");
                CrystalTriggerTime = Time.time;
            }

        }
    }

    private void WinTrigger()
    {
        Crystal.SetActive(true);
    }
}

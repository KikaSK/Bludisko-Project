using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotSpeed = 500.0f;
    public float movSpeed = 5.0f;
   
    private float main_time;
    public float click_time;
    private float two_click_time;
    private int count;
    private float two_twoClicks;
    private float time;

    public bool MenuOpen;
    public GameObject Paper1;
    public GameObject Paper2;
    public GameObject Paper3;
    public GameObject Paper4;
    public GameObject Paper5;

    public bool WinArchimedes = false;
    public bool WinPyramids = false;
    public bool WinHarry = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.eulerAngles = new Vector3(0, 0, 0);
        Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
        Paper1.SetActive(true);
        Paper2.SetActive(false);
        Paper3.SetActive(false);
        Paper4.SetActive(false);
        Paper5.SetActive(false);
        MenuOpen = true;
    }
    private void SingleClick()
    {
        if(MenuOpen)
        {
            Paper1.SetActive(false);
            Paper2.SetActive(false);
            Paper3.SetActive(false);
            Paper4.SetActive(false);
            MenuOpen = false;
        }
        // MyClick();
        //Debug.Log("Single Click");
    }

    private void DoubleClick()
    {
        //Debug.Log("Double Click");
    }

    private void LongPress()
    {
        //Debug.Log("Long Press");
        if (!MenuOpen)
        {
            float angle = transform.rotation.eulerAngles.y;
            transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * Time.deltaTime * movSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed, 0);
        Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * rotSpeed, 0, 0);

        if (Input.GetMouseButton(0))
        {
            if (main_time == 0.0f)
            {
                main_time = Time.time;
            }
            if (Time.time - main_time > 0.2f)
            {
                //Let's put the actions that are executed on time
                LongPress();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Time.time - main_time < 0.2f)
            {// when the mouse is raised, the time from pressing to lifting is detected. If it is less than 2.0f, it is judged as a click.
                SingleClick();
                if (two_twoClicks != 0 && Time.time - two_twoClicks < 0.2f)
                {
                    count = 2;
                }
                else
                {
                    count++;
                    if (count == 1)
                    {
                        time = Time.time;
                    }
                }
                if (count == 2
                 && ((time != 0 && Time.time - time < 0.2f) || (two_twoClicks != 0 && Time.time - two_twoClicks < 0.2f)))
                {// if the two click event is less than 0.2f, it is judged as double click
                 //Code block to execute when double clicking
                    DoubleClick();
                    count = 0;
                }
                if (count == 2 && (Time.time - time > 0.2f || Time.time - two_twoClicks > 0.2f))
                {
                    two_twoClicks = Time.time;
                    count = 0;
                }
                main_time = 0.0f;
            }
            else
            {
                main_time = 0.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ArchimedesPaperTag") && !GetComponent<PlayerInRoomController>().IsInArchimedesRoom && !WinArchimedes)
        {
            Paper2.SetActive(true);
            MenuOpen = true;
        }
        if (other.CompareTag("HarryPaperTag") && !GetComponent<PlayerInRoomController>().IsInHarryRoom && !WinHarry)
        {
            Paper3.SetActive(true);
            MenuOpen = true;
        }
        if (other.CompareTag("PyramidsPaperTag") && !GetComponent<PlayerInRoomController>().IsInPyramidsRoom && !WinPyramids)
        {
            Paper4.SetActive(true);
            MenuOpen = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("WallTag"))
        {
            float angle = transform.rotation.eulerAngles.y;
            transform.position -= new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * Time.deltaTime * movSpeed;
        }
    }
}
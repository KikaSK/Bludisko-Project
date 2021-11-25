using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotSpeed = 500.0f;
    public float movSpeed = 5.0f;
    /*
    public GameObject LookTransform;
    bool isTeleporting = false;
    private Vector3 StartPos = Vector3.zero;
    private Vector3 EndPos = Vector3.zero;
    float t = 0f;
    public float TeleportSpeed = 2f;
    */
    /*
    private float LastClickTime = -10f;
    private bool click_managed;
    */
    private float main_time;
    public float click_time;
    private float two_click_time;
    private int count;
    private float two_twoClicks;//= -10f;
    private float time;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.eulerAngles = new Vector3(0, 0, 0);
        Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    /*
    private float doubleClickTimeLimit = 0.25f;

    protected void Start()
    {
        StartCoroutine(InputListener());
        Cursor.lockState = CursorLockMode.Locked;
        transform.eulerAngles = new Vector3(0, 0, 0);
        Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
        click_managed = true;
    }

    // Update is called once per frame
    private IEnumerator InputListener()
    {
        while (enabled)
        { //Run as long as this is activ

            if (Input.GetMouseButtonDown(0))
                yield return ClickEvent();

            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        //pause a frame so you don't pick up the same mouse down event.
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while (count < doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }
            count += Time.deltaTime;// increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
        SingleClick();
    }
     */

    private void SingleClick()
    {
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
        float angle = transform.rotation.eulerAngles.y;
        transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * Time.deltaTime * movSpeed;

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

        /*
        if (isTeleporting)
        {
            transform.position = Vector3.Lerp(StartPos, EndPos, t);
            t += TeleportSpeed * Time.deltaTime;
            isTeleporting = t <= 1f;
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            LookTransform.transform.position = hit.point;
        }
        */
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("WallTag"))
        {
            
            float angle = transform.rotation.eulerAngles.y;
            transform.position -= new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * Time.deltaTime * movSpeed;
        }
    }

    private void MyClick()
    {
        /*
            t = 0f;
            isTeleporting = true;
            StartPos = transform.position;
            EndPos = new Vector3(LookTransform.transform.position.x, transform.position.y, LookTransform.transform.position.z);
            EndPos = 0.9f * (EndPos - StartPos) + StartPos;
        */
        
        
            /*
             * float angle = transform.rotation.eulerAngles.y;
            transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * Time.deltaTime * movSpeed;
        */
        
    }
}
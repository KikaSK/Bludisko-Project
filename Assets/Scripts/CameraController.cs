using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotSpeed = 500.0f;
    public float movSpeed = 5.0f;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.eulerAngles = new Vector3(0, 0, 0);
        Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed, 0);
        Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * rotSpeed, 0, 0);

        if (Input.GetKey("w"))
        {
            float angle = transform.rotation.eulerAngles.y;
            transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * Time.deltaTime * movSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
         * Debug.Log(other.name);
        if (other.gameObject.CompareTag("WallTag"))
        {
            Debug.Log(other.name);
            float angle = transform.rotation.eulerAngles.y;
            transform.position -= new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * Time.deltaTime * movSpeed;
        }*/

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("WallTag"))
        {
            Debug.Log(other.name);
            float angle = transform.rotation.eulerAngles.y;
            transform.position -= new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * Time.deltaTime * movSpeed;
        }
    }
}
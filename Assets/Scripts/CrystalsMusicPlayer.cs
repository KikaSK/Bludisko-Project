using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsMusicPlayer : MonoBehaviour
{

    bool PlaySound = true;
    float T = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - T > 5f)
        {
            PlaySound = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CrystalTag") && PlaySound)
        {
            GetComponent<AudioSource>().Play();
            T = Time.time;
            PlaySound = false;
        }
    }
}

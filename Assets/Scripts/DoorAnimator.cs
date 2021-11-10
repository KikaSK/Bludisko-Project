using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private Animator anim;
    private bool Start1 = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Start1)
        {
            Debug.Log("zaciatok");
            anim.SetBool("character_nearby", false);
            Start1 = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("character_nearby", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("character_nearby", false);
    }

    
}

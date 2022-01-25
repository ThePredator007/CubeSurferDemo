using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableControl : MonoBehaviour
{
    public bool ToplandiMi = false;

    AudioSource audio;
   
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
            Destroy(gameObject,0.07f);
            audio.Play();
        }
       
    }

}

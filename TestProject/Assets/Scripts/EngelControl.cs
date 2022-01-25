using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelControl : MonoBehaviour
{
    bool CarptiMi = false;
    GameObject GameManager;

    AudioSource audio;

    void Awake()
    {
        GameManager = GameObject.Find("GameManager");

        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision col)
    //{
    //    if (!CarptiMi)
    //    {
    //        if (col.gameObject.tag == "collectable")
    //        {
    //            col.gameObject.transform.parent = null;
    //            CarptiMi = true;

    //        }
    //    }
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (!CarptiMi)
        {
            if (other.gameObject.tag == "collectable")
            {
                other.gameObject.transform.parent = null;
                CarptiMi = true;
                audio.Play();

            }
            if (other.gameObject.tag == "Player")
            {
                GameManager.GetComponent<GameManagerControl>().GameOver();
                FindObjectOfType<PlayerControl>().canMove = false;
            }
        }
    }
}

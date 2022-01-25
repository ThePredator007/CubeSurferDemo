using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorControl : MonoBehaviour
{
    [SerializeField]
    GameObject MainCube;

    public Text ToplamKup;

    public int ObjeCount = 1;

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

        if (other.gameObject.tag == "collectable")
        {

            if (!other.gameObject.GetComponent<CollectableControl>().ToplandiMi)
            {
                MainCube.transform.position += new Vector3(0, 1f, 0);
                audio.Play();
                other.gameObject.transform.position = new Vector3(MainCube.transform.position.x, MainCube.transform.position.y - 1, MainCube.transform.position.z);
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                other.gameObject.transform.parent = MainCube.transform;
                other.gameObject.GetComponent<CollectableControl>().ToplandiMi = true;
                ObjeCount++;
                ToplamKup.text = "Toplanan küp " + ObjeCount;
            }
            
            
        }

        if (other.gameObject.tag == "Finish")
        {
            FindObjectOfType<GameManagerControl>().Finish();
            FindObjectOfType<PlayerControl>().canMove = false;
            FindObjectOfType<PlayerControl>().finish = true;
            FindObjectOfType<PlayGames>().AddScoreToLeaderboard(ObjeCount);
        }
    }
}

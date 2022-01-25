using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public float sensitivity = .16f, clampDelta = 42f;
    public float forwardSpeed = 5;
    public bool canMove = false, finish = false;


    private Vector3 MoveDes;
    private Vector3 lastMousePos;


    private Rigidbody rigid;


    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();

        MoveDes = new Vector3(5, 0, 0);
    }

    
    void Update()
    {    

        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -5, 5));
    }

    void FixedUpdate()
    {
        
        if (!canMove && !finish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePos = Input.mousePosition;
                canMove = true;
                FindObjectOfType<GameManagerControl>().StartGame();
                animator.SetBool("Kos", true);
            }
        }
        

        if (canMove)
        {
            transform.position += -MoveDes * Time.deltaTime * forwardSpeed;
        }

        if (canMove)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 vector = lastMousePos - Input.mousePosition;
                lastMousePos = Input.mousePosition;
                vector = new Vector3(0, 0, vector.x);

                Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
                rigid.AddForce(-moveForce * sensitivity, ForceMode.VelocityChange);//-moveForce da (-) koymamýzýn nedeni mouse pozisyonun ters tarafýna gitmesi (-) koyarak mouse olan yere gitmesini saðlýyoruz 
            }
        }

        rigid.velocity.Normalize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
            FindObjectOfType<GameManagerControl>().GameOver();
        }
    }

}

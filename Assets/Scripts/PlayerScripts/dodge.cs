using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodge : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;
    public GameObject lol;
    private Rigidbody rb;

    void Start()
    {
        rb = lol.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if(Input.GetKey(KeyCode.A)){
            //rb.AddForce(new Vector3(0, 0, speed));
            //new Vector3(0, 0, speed);
            //rb.velocity = transform.TransformDirection(new Vector3(0,0,speed));
            rb.AddForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
            Debug.Log("Pressed A");
        }
        else if(Input.GetKey(KeyCode.D)){
            //rb.AddForce(new Vector3(0, 0, -speed));
            //rb.velocity = new Vector3(0, 0, -speed);
            //rb.velocity = transform.TransformDirection(new Vector3(0,0,-speed));
            rb.AddForce(new Vector3(0, 0, -speed), ForceMode.VelocityChange);
            Debug.Log("Pressed D");
        }*/
        float Horizontal = Input.GetAxis("Horizontal");
        if(Horizontal < 0){
            rb.AddForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
            Debug.Log("Pressed A");
        }
        else if(Horizontal > 0)
        {
            rb.AddForce(new Vector3(0, 0, -speed), ForceMode.VelocityChange);
            Debug.Log("Pressed D");
        }
        else{
            //rb.velocity = new Vector3(0,0,0);
        }
    }
}

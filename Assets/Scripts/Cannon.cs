using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cannon : MonoBehaviour
{
    [SerializeField] private ParticleSystem BarrelFlash;
    [SerializeField] private AudioSource FlashSound;
    public GameObject cannonball;
    public float rateOfFire = 0.8f;
    private float fireDelay;
    public float force = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        //RaycastHit hit;
        if(Input.GetMouseButton(0) && Time.time > fireDelay)
        {       
            BarrelFlash.Play();
            FlashSound.Play();
            fireDelay = Time.time + rateOfFire;
            GameObject clone = Instantiate(cannonball, transform.position, transform.rotation);
            Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
            cloneRB.velocity = transform.TransformDirection(new Vector3(0,force,0));
            Physics.IgnoreCollision(clone.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
    }  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject player;
    public GameObject cannonball;
    private int rateOfFire;
    [SerializeField] private int Heatlth = 20;
    
    private GameObject clone;
    private float fireDelay;
    [SerializeField] private float force = 500;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {       
        if(Heatlth <= 0){
            die();
        } 
        rateOfFire = Random.Range(3,7);
        shoot();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Player")){
            Heatlth-=5;
        }
    }
    void die(){
        gameObject.SetActive(false);
    }
    void shoot()
    {
        transform.parent.LookAt(player.transform);
        if(Time.time > fireDelay)
        {       

            //BarrelFlash.Play();
            //FlashSound.Play();
            fireDelay = Time.time + rateOfFire;
            clone = Instantiate(cannonball, transform.position, transform.rotation);
            Physics.IgnoreCollision(clone.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
            cloneRB.velocity = transform.TransformDirection(new Vector3(0,0,force));

            
            
        }
    }  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Cannon : MonoBehaviour
{
    [SerializeField] private ParticleSystem BarrelFlash;
    [SerializeField] private AudioSource FlashSound;
    public GameObject cannonball;
    public float rateOfFire = 0.8f;
    private float fireDelay;
    public float force = 20;
    [SerializeField] private int CannonballsLeft = 10;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject PlayerUI;
    GameObject numberOfHits;

    private int startScore = 0;

    private Scene sceneMain;
    private Scene scenePrediction;
    private PhysicsScene scenePredictionPhysics;
    private PhysicsScene sceneMainPhysics;
    private bool canShoot = true;
    private bool cheatsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        numberOfHits = GameObject.Find("Pataikymai");
        startScore = int.Parse(numberOfHits.GetComponent<Text>().text);
        healthBar.SetMaxHealth(CannonballsLeft);
        Physics.autoSimulation = false;
        //sceneMain = SceneManager.CreateScene("MainScene");
        //sceneMainPhysics = sceneMain.GetPhysicsScene();

        CreateSceneParameters sceneParam = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
        scenePrediction = SceneManager.CreateScene("ScenePredicitonPhysics", sceneParam);
        scenePredictionPhysics = scenePrediction.GetPhysicsScene();
    }

    private void FixedUpdate()
    {
        if (!sceneMainPhysics.IsValid())
            return;

        sceneMainPhysics.Simulate(Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if(!cheatsOn){
            healthBar.SetHealth(CannonballsLeft-=3);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(!cheatsOn){
                Debug.Log("Cheats are On");
                cheatsOn = true;              
            }else{
                Debug.Log("Cheats are Off");
                cheatsOn = false;
            }
        }
        int i = int.Parse(numberOfHits.GetComponent<Text>().text);
        int temp = i - startScore;
        if(temp >= 9)
        {
            startScore = i;
            CannonballsLeft += 10;
        }
        shoot();
    }

    void gameOver(){
        GameOverUI.SetActive(true);
        PlayerUI.SetActive(false);
        Invoke("StopTime", 1);
    }
    
    void shoot()
    {
        

        GameObject predictionBall = Instantiate(cannonball, transform.position, transform.rotation);
        SceneManager.MoveGameObjectToScene(predictionBall, scenePrediction);
        predictionBall.GetComponent<Rigidbody>()//.AddForce(new Vector3(0,force,0),ForceMode.Impulse);
        .velocity = transform.TransformDirection(new Vector3(0,force,0));

        // Material redMaterial = new Material(Shader.Find("Diffuse"));
        // redMaterial.color = Color.blue;
        
        //simulate(predictionBall);
        //StartCoroutine(simulate(predictionBall));
        for (int i = 0; i < 25; i++)
        { 
            scenePredictionPhysics.Simulate(
            //Time.fixedDeltaTime
            0.025f
            );

            GameObject pathMarkSphere = Instantiate(cannonball, transform.position, transform.rotation);
            pathMarkSphere.GetComponent<Collider>().isTrigger = true;
            pathMarkSphere.transform.localScale = new Vector3(.7f, 3, .7f);
            pathMarkSphere.transform.position = predictionBall.transform.position;
            pathMarkSphere.GetComponent<MeshRenderer>().material = cannonball.GetComponent<MeshRenderer>().sharedMaterial;
            SceneManager.MoveGameObjectToScene(pathMarkSphere, scenePrediction);
            Destroy(pathMarkSphere, .005f);
        }
    
        if(Input.GetMouseButton(0) && Time.time > fireDelay && canShoot)
        {       
            if(!cheatsOn){
                CannonballsLeft--;
                healthBar.SetHealth(CannonballsLeft);
            }
            if(CannonballsLeft < 1){
                canShoot = false;
                gameOver();
            }
            if (!sceneMainPhysics.IsValid() || !scenePredictionPhysics.IsValid())
            return;
            BarrelFlash.Play();
            FlashSound.Play();
            fireDelay = Time.time + rateOfFire;

            GameObject clone = Instantiate(cannonball, transform.position, transform.rotation);
            clone.tag = "Player";
            //clone.AddComponent<TimeRewind>();
            Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
            cloneRB
            .velocity = transform.TransformDirection(new Vector3(0,force,0));

            Physics.IgnoreCollision(clone.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            
        }
        Destroy(predictionBall);
    }  
}

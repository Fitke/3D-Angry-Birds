using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// games objects Center Position
//const Vector3 GOCP = new Vector3(0,0,0);
public class Explosion : MonoBehaviour {

    //[SerializeField] private ParticleSystem explosion;
    //public GameObject ggates;
    GameObject WinText;
    GameObject numberOfHits;
    GameObject piece;
    private Rigidbody rb;
    public float cubeSize = 0.5f;
    private float cubesInX;
    private float cubesInY;
    private float cubesInZ;
    private GameObject ShadowObject;
    GameObject Camera;
    float cubesPivotDistanceX;
    float cubesPivotDistanceY;
    float cubesPivotDistanceZ;
    Vector3 cubesPivot;
    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    private int totalScore = 0;
    private int tempScore = 0;

    // Use this for initialization
    void Start() {
        if(transform.root.GetComponent<Collider>() != null){
            Physics.IgnoreCollision(GetComponent<Collider>(), transform.root.GetComponent<Collider>());
        }
        Camera = GameObject.Find("Main Camera");
        WinText = GameObject.Find("PATAIKEI!");
        numberOfHits = GameObject.Find("Pataikymai");
        rb = GetComponent<Rigidbody>();
        ShadowObject = new GameObject("vardas");
        ShadowObject.AddComponent<Rigidbody>(); 
        //ShadowObject.transform.rotation = transform.rotation;
        ShadowObject.transform.position = transform.position;      
   
        if(transform.parent.gameObject != null && !gameObject.Equals(transform.parent.gameObject))
        {
            cubeSize = cubeSize * transform.parent.gameObject.transform.localScale.x;
            cubesInX = transform.parent.gameObject.transform.localScale.x * transform.localScale.x / cubeSize;
            cubesInY = transform.parent.gameObject.transform.localScale.y * transform.localScale.y / cubeSize;
            cubesInZ = transform.parent.gameObject.transform.localScale.z * transform.localScale.z / cubeSize;
        } else {
            cubesInX = transform.localScale.x / cubeSize;
            cubesInY = transform.localScale.y / cubeSize;
            cubesInZ = transform.localScale.z / cubeSize;
        }
        
        //calculate pivot distance
        cubesPivotDistanceX = cubeSize * cubesInX / 2;
        cubesPivotDistanceY = cubeSize * cubesInY / 2;
        cubesPivotDistanceZ = cubeSize * cubesInZ / 2;

        cubesPivot = new Vector3(cubesPivotDistanceX, cubesPivotDistanceY, cubesPivotDistanceZ);

    }

    // Update is called once per frame
    void Update() {
        //ShadowObject.transform.rotation = transform.rotation;
        ShadowObject.transform.position = transform.position; 
    }

    private void OnTriggerEnter(Collider other) {
        explode();
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        totalScore = int.Parse(numberOfHits.GetComponent<Text>().text);
        totalScore++;
        if(tempScore >= 9)
        {
            totalScore+=10;
            tempScore = 0;
        }
        tempScore++;
        numberOfHits.GetComponent<Text>().text = totalScore.ToString();
    }

    public void explode() {
        //Camera.GetComponent<deactivatedGameObjects>().Add(gameObject);
        gameObject.SetActive(false);
        //print($"{gameObject.name} was hit");
        GameObject sound = GameObject.Find("Punch Hit Sound Effect");
        sound.GetComponent<AudioSource>().Play();

        
        for (int x = 0; x < cubesInX; x++) {
            for (int y = 0; y < cubesInY; y++) {
                for (int z = 0; z < cubesInZ; z++) {
                    createPiece(x, y, z);
                }
            }
        }        
        ShadowObject.transform.rotation = transform.rotation;
        //shadowRB.transform.rotation = transform.rotation;

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders) {
            //get rigidbody from collider object
            Rigidbody rbb = hit.GetComponent<Rigidbody>();
            if (rbb != null) {
                //add explosion force to this body with given parameters
                rbb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z) {

        //create piece
        Rigidbody pieceRB;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //piece.AddComponent<TimeRewind>();

        //set piece position and scale
        piece.transform.parent = ShadowObject.transform;
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        piece.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
    

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize*cubeSize*cubeSize;     

        pieceRB = piece.GetComponent<Rigidbody>();
        pieceRB.velocity = rb.velocity;
        Destroy(piece, 10f);
    }

}

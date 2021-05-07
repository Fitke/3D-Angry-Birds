using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewind : MonoBehaviour
{
    [SerializeField] private bool isRewinding = false;
    //Animator animation;
    List<ReferenceInTime> positions;
    public bool canCreatVoxel = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //animation = Resources.Load<Animator>("Assets/materials/Animations/Target movment.anim");
        positions = new List<ReferenceInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        else if(Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }
    }

    void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    void StartRewind(){
        isRewinding = true;
    }
    void StopRewind(){
        isRewinding = false;
        rb.isKinematic = false;
    }
    void Record(){
        positions.Insert(0, new ReferenceInTime(
        transform.position,
        transform.rotation,
        GetComponent<Rigidbody>().velocity,
        GetComponent<Rigidbody>().angularVelocity));
    }

    void Rewind()
    {
        if(positions.Count > 0)
        {
            ReferenceInTime positionInTime = positions[0];
            transform.position = positionInTime.Position;
            transform.rotation = positionInTime.Rotation;
            GetComponent<Rigidbody>().velocity = positionInTime.Velocity;
            GetComponent<Rigidbody>().angularVelocity = positionInTime.AngularVelocity;
            positions.RemoveAt(0);
            //animation.SetFloat("Speed", -1f);
        }
        else{
            canCreatVoxel = true;
            Destroy(gameObject);
            GameObject camera = GameObject.Find("Main Camera");
            List<GameObject> gameObjects = camera.GetComponent<deactivatedGameObjects>().GetAll();
            //animation.SetFloat("Speed", 1f);
            for(int i = 0; i < gameObjects.Count; i++)
            {
                // if(gameObjects[i].activeSelf)
                // {

                // }
                gameObjects[i].SetActive(true);
            }
            StopRewind();
        }
    }
}

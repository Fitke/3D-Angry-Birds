using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public int numberOfSpawns = 15;
    [SerializeField] private int XExcl;
    [SerializeField] private int XInc; 
    int randPosX;
    int randPosZ;
    int randSide;
    public GameObject ggates;
    // Start is called before the first frame update
    void Start()
    {
        //spawnGates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnGates()
    {

        for(int i = 0; i < numberOfSpawns; i++)
        {
            randPosX = Random.Range(XExcl,XInc);
            randPosZ = Random.Range(-80,81);          
            GameObject gatesSpawn = GameObject.Instantiate(ggates);
            gatesSpawn.transform.position = new Vector3(randPosX,0,randPosZ);
        }
    }
}

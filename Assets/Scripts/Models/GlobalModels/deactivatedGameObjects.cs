using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivatedGameObjects : MonoBehaviour
{
    private List<GameObject> deactivated;
    void Start()
    {
       deactivated = new List<GameObject>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(GameObject gO){
        deactivated.Add(gO);
    }
    public List<GameObject> GetAll()
    {
        return deactivated;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayTheSound();
    }


    private void PlayTheSound()
    {
        sound.Play();
    }

    private void OnTriggerEnter(Collider other) 
    {
        print("Playing hit Sound Effect");
        sound.Play();
    }
        
}

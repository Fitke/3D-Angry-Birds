using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFallEndGame : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject PlayerUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Time.timeScale = 0f;
        GameOverUI.SetActive(true);
        PlayerUI.SetActive(false);
        //Invoke("StopTime", 1);
        Time.timeScale = 0f;
    }
}

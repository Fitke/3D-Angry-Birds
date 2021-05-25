using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    public GameObject cannon;
    public GameObject player;
    public GameObject VictoryUI;
    public GameObject PlayerUI;

    /*private void OnTriggerEnter(Collider collision)
    {
        Time.timeScale = 0f;
        VictoryUI.SetActive(true);
        PlayerUI.SetActive(false);
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Floor")){
            player.GetComponent<CameraScript>().enabled = false;
            cannon.GetComponent<Cannon>().enabled = false;
            Time.timeScale = 0f;
            VictoryUI.SetActive(true);
            PlayerUI.SetActive(false);
        }
    }
    public void NextLvl()
    {
        Debug.Log("Won");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GameFinished()
    {
        Debug.Log("Won");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MAIN MENU");
    }
}

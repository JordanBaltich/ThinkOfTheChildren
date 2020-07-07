using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   // GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(3);
        }
      
        /*if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(4);
        }*/
    }
    
}

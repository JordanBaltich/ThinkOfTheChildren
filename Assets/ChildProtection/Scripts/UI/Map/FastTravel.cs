using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FastTravel : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform targetDestination;

    [SerializeField] GameObject mapCamera;
    [SerializeField] GameObject FastTravelUI;
    float speed;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        speed = player.GetComponent<NavMeshAgent>().speed;
    }

    public void TravelToDestination()
    {
        player.GetComponent<PlayerMovement>().destinationPosition = targetDestination.position;
        player.transform.position = targetDestination.position;

        if (player.transform.position == targetDestination.position)
        {
            mapCamera.SetActive(false);
            FastTravelUI.SetActive(false);
            player.SetActive(true);
        }
    }

}

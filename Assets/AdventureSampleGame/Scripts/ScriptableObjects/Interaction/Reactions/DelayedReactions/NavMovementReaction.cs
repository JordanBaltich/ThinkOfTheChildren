using UnityEngine;
using UnityEngine.AI;

public class NavMovementReaction : DelayedReaction
{
    public NavMeshAgent agent;       // The navmeshagent to be turned on or off.
    public GameObject targetLocation;
    public float speed = 2;

    protected override void ImmediateReaction()
    {
        Debug.Log("Moving");
        agent.SetDestination(targetLocation.transform.position);
        if(!agent.GetComponent<PlayerMovement>())
            agent.speed = speed;
    }
}
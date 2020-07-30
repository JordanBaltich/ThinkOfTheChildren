using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class PartnerAI : MonoBehaviour
{
    PlayerMovement player;
    NavMeshAgent m_Agent;
    Animator m_Animator;
    public float speedDampTime = 0.1f;
    public float turnSpeedThreshold = 0.5f;
    public float slowingSpeed = 0.175f;
    public float turnSmoothing = 15f;  

    [SerializeField] float maxDisFromPlayer;
    [SerializeField] Vector3 offset;

    private readonly int hashSpeedPara = Animator.StringToHash("Speed");
    public Vector3 destinationPosition;
    private bool isRunning;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        if (GameObject.FindObjectOfType<PlayerMovement>() == null)
        {
            Debug.Log("Player is missing.");
            return;
        }
        player = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Agent.enabled)
        {
            float speed = m_Agent.desiredVelocity.magnitude;

        // If the nav mesh agent is very close to it's destination, call the Stopping function.
        if (m_Agent.remainingDistance <= m_Agent.stoppingDistance * 0.1f)
            Stopping(out speed);
        // Otherwise, if the nav mesh agent is close to it's destination, call the Slowing function.
        else if (m_Agent.remainingDistance <= m_Agent.stoppingDistance)
            Slowing(out speed, m_Agent.remainingDistance);
        // Otherwise, if the nav mesh agent wants to move fast enough, call the Moving function.
        else if (speed > turnSpeedThreshold)
            Moving();

        // Set the animator's Speed parameter based on the (possibly modified) speed that the nav mesh agent wants to move at.
        m_Animator.SetFloat(hashSpeedPara, speed, speedDampTime, Time.deltaTime);
        m_Animator.speed = 1 + (GetDistanceFromPlayer() / 25);

        }
        else
        {
            m_Agent.SetDestination(transform.position);
        }

        if (GetDistanceFromPlayer() > maxDisFromPlayer)
        {
            transform.position = player.transform.position - offset;
        }
    }

    private void LateUpdate()
    {
        if(player.agent.isStopped == false)
        {
            SetDestination();
        }

        if (player.isRunning && isRunning == false)
        {
            m_Animator.SetTrigger("Run");
            isRunning = true;
        }
    }

    public void SetDestination()
    {
        destinationPosition = Vector3.Lerp(player.transform.position-offset,player.destinationPosition,0.1f);

        // Set the destination of the nav mesh agent to the found destination position and start the nav mesh agent going.
        m_Agent.SetDestination(destinationPosition);

        m_Agent.isStopped = false;

        
    }

    // This is called when the nav mesh agent is very close to it's destination.
    private void Stopping(out float speed)
    {
        // Stop the nav mesh agent from moving the player.
        m_Agent.isStopped = true;

        // Set the player's position to the destination.
        transform.position = destinationPosition;

        // Set the speed (which is what the animator will use) to zero.
        speed = 0f;
    }

    private void Slowing(out float speed, float distanceToDestination)
    {
        // Although the player will continue to move, it will be controlled manually so stop the nav mesh agent.
        m_Agent.isStopped = true;
        isRunning = false;

        // Find the distance to the destination as a percentage of the stopping distance.
        float proportionalDistance = 1f - distanceToDestination / m_Agent.stoppingDistance;

        // The target rotation is the rotation of the interactionLocation if the player is headed to an interactable, or the player's own rotation if not.
        Quaternion targetRotation = player.transform.rotation;

        // Interpolate the player's rotation between itself and the target rotation based on how close to the destination the player is.
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, proportionalDistance);

        // Move the player towards the destination by an amount based on the slowing speed.
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, slowingSpeed * Time.deltaTime);

        // Set the speed (for use by the animator) to a value between slowing speed and zero based on the proportional distance.
        speed = Mathf.Lerp(slowingSpeed, 0f, proportionalDistance);
    }

    // This is called when the player is moving normally.  In such cases the player is moved by the nav mesh agent, but rotated by this function.
    private void Moving()
    {

        // Create a rotation looking down the nav mesh agent's desired velocity.
        Quaternion targetRotation = Quaternion.LookRotation(m_Agent.desiredVelocity);

        // Interpolate the player's rotation towards the target rotation.
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
    }

    private void OnAnimatorMove()
    {
            // Set the velocity of the nav mesh agent (which is moving the player) based on the speed that the animator would move the player.
            m_Agent.velocity = m_Animator.deltaPosition / Time.deltaTime;
    }

    float GetDistanceFromPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        return distance;
    }

    //float MoveSpeed()
    //{
    //    float speed = 1 + (GetDistanceFromPlayer() / 25);

    //    return speed;
    //}
}

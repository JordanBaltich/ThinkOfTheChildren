using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class PartnerAI : MonoBehaviour
{
    Transform player;
    NavMeshAgent m_Agent;
    Animator m_Animator;

    [SerializeField] float maxDisFromPlayer;
    [SerializeField] Vector3 offset;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        if (GameObject.FindObjectOfType<PlayerMovement>() == null)
        {
            Debug.Log("Player is missing.");
            return;
        }
        player = GameObject.FindObjectOfType<PlayerMovement>().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        m_Animator.SetFloat("Speed", m_Agent.velocity.magnitude);
        m_Agent.speed = MoveSpeed();

        if (GetDistanceFromPlayer() > maxDisFromPlayer)
        {
            transform.position = player.position - offset;
        }
    }

    private void LateUpdate()
    {
        m_Agent.SetDestination(player.position);
    }

    float GetDistanceFromPlayer()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        return distance;
    }

    float MoveSpeed()
    {
        float speed = 1 + (GetDistanceFromPlayer() / 25);

        return speed;
    }
}

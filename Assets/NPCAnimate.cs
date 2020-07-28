using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimate : MonoBehaviour
{
    Transform player;
    NavMeshAgent m_Agent;
    Animator m_Animator;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        m_Animator.SetFloat("Speed", m_Agent.velocity.magnitude);

    }

}
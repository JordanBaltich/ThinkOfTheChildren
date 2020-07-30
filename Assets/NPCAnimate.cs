using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using DialogueEditor;

public class NPCAnimate : MonoBehaviour
{
    Transform player;
    NavMeshAgent m_Agent;
    Animator m_Animator;
    public string defaultAnimation;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();        
    }

    private void Start()
    {
        m_Animator.SetTrigger(defaultAnimation);
        ConversationManager.OnConversationEnded += GoBackToDefault;
    }

    private void GoBackToDefault()
    {
        m_Animator.SetTrigger(defaultAnimation);
    }

    // Update is called once per frame
    void Update()
    {
        m_Animator.SetFloat("Speed", m_Agent.velocity.magnitude);
    }

}
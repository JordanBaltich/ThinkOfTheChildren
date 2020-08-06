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
    private readonly int hashSpeedPara = Animator.StringToHash("Speed");

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();        
    }

    private void Start()
    {
        if (m_Animator != null)
            m_Animator.SetTrigger(defaultAnimation);
        ConversationManager.OnConversationEnded += GoBackToDefault;
    }

    private void GoBackToDefault()
    {
        if(m_Animator != null)
        m_Animator.SetTrigger(defaultAnimation);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Agent.enabled)
        {

              float speed = m_Agent.desiredVelocity.magnitude;

              m_Animator.SetFloat(hashSpeedPara, speed, 0.1f, Time.deltaTime);

        }
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            m_Animator.SetTrigger(defaultAnimation);
        }
    }

    private void OnAnimatorMove()
    {

    }

}
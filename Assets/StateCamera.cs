﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.Animations;
using Cinemachine;
using System;

public class StateCamera : MonoBehaviour
{
    Animator m_animator;
    CinemachineStateDrivenCamera m_StateDriver;
    int cameraNum;
    CinemachineVirtualCameraBase[] m_Cameras;

    public static StateCamera Instance { get; private set; }

    private void Awake()
    {
        // Destroy myself if I am not the singleton
        if (Instance != null && Instance != this)
        {
            GameObject.Destroy(this.gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_StateDriver = GetComponent<CinemachineStateDrivenCamera>();
        m_Cameras = m_StateDriver.ChildCameras;

        ConversationManager.OnConversationStarted += SwitchInToConversation;
        ConversationManager.OnConversationEnded += SwitchOutOfConversation;
    }

    private void SwitchOutOfConversation()
    {
        if (m_animator != null)
        {
            ResetTriggers();
            m_animator.SetTrigger("EndConversation");
        }
    }

    private void SwitchInToConversation()
    {
        //m_animator.SetTrigger("FocusOnChild" + cameraNum.ToString());
    }

    public void SwitchToPlayer()
    {
        if(m_animator==null)
            m_animator = GetComponent<Animator>();

        ResetTriggers();
        m_animator.SetTrigger("FocusOnPlayer");
    }

    public void SwitchToChild(int childNum)
    {
        if (m_animator == null)
            m_animator = GetComponent<Animator>();

        ResetTriggers();
        m_animator.SetTrigger("FocusOnChild" + childNum.ToString());
    }

    public void SwitchToAdult()
    {
        if (m_animator == null)
            m_animator = GetComponent<Animator>();
        
        if (m_animator.gameObject.activeSelf)
        {
            ResetTriggers();
            m_animator.SetTrigger("FocusOnAdult");
        }
    }

    public void SwitchToCivilian()
    {
        if (m_animator == null)
            m_animator = GetComponent<Animator>();

        ResetTriggers();
        m_animator.SetTrigger("FocusOnCivilian");
    }

    public void SetChildCamera(GameObject target)
    {
        m_Cameras[2].LookAt = target.transform;
        m_Cameras[2].Follow = target.transform;
    }

    public void SetAdultCamera(GameObject target)
    {
        m_Cameras[3].LookAt = target.transform;
        m_Cameras[3].Follow = target.transform;
    }

    public void SetCivilanCamera(GameObject target)
    {
        m_Cameras[4].LookAt = target.transform;
        m_Cameras[4].Follow = target.transform;
    }

    void ResetTriggers()
    {
        if (m_animator != null)
        {
            m_animator.ResetTrigger("EndConversation");
            m_animator.ResetTrigger("FocusOnPlayer");
            m_animator.ResetTrigger("FocusOnAdult");
            m_animator.ResetTrigger("FocusOnCivilian");
            m_animator.ResetTrigger("FocusOnChild1");
            m_animator.ResetTrigger("FocusOnChild2");
            m_animator.ResetTrigger("FocusOnChild3");
        }
    }

}

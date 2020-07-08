using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyInfoDisplay : MonoBehaviour
{
    [HideInInspector]
    public TMP_Text infoDescription;    // The Image components that display the Items.
    private enum eState
    {
        ScrollingText,
        Idle,
        Off,
        NONE,
    }
    [HideInInspector]
    public float ScrollSpeed = 2;
    private float m_elapsedScrollTime;
    private int m_scrollIndex;
    [HideInInspector]
    public int m_targetScrollTextCount;
    private eState m_state;
    private float m_stateTime;
    private Journal m_journal;
    private int m_currentSelectedIndex = 0;

    public void SetUp()
    {
        m_journal = FindObjectOfType<Journal>();
        infoDescription = GetComponent<TMP_Text>();
        ScrollSpeed = m_journal.scrollSpeed;
    }

    private void OnEnable()
    {        
        SetState(eState.ScrollingText);
    }

    private void Update()
    {
        if (!m_journal.journalIsDisplayed)
        {
            SetState(eState.Off);
        }        

        switch (m_state)
        {
            case eState.ScrollingText:
                UpdateScrollingText();
                break;
            case eState.Off:
                SkipTextScroll();
                break;
            
        }
    }

    private void SkipTextScroll()
    {
        if (m_scrollIndex <= m_targetScrollTextCount)
        {
            m_scrollIndex = m_targetScrollTextCount;
            infoDescription.maxVisibleCharacters = m_scrollIndex;
        }
    }

    private void UpdateScrollingText()
    {
        const float charactersPerSecond = 1500;
        float timePerChar = (60.0f / charactersPerSecond);
        timePerChar *= ScrollSpeed;

        m_elapsedScrollTime += Time.deltaTime;

        if (m_elapsedScrollTime > timePerChar)
        {
            m_elapsedScrollTime = 0f;

            infoDescription.maxVisibleCharacters = m_scrollIndex;
            m_scrollIndex++;

            // Finished?
            if (m_scrollIndex >= m_targetScrollTextCount)
            {
                SetState(eState.Idle);
            }
        }
    }

    public void WriteNote(KeyInfo keyInfo)
    {
        if (keyInfo == null)
        {            
            return;
        }
        m_currentSelectedIndex = 0;
        if (string.IsNullOrEmpty(keyInfo.Description))
        {
            infoDescription.text = "";
            m_targetScrollTextCount = 0;
            infoDescription.maxVisibleCharacters = 0;
            m_elapsedScrollTime = 0f;
            m_scrollIndex = 0;
        }
        else
        {
            infoDescription.text = keyInfo.Description;
            m_targetScrollTextCount = keyInfo.Description.Length + 1;
            infoDescription.maxVisibleCharacters = 0;
            m_elapsedScrollTime = 0f;
            m_scrollIndex = 0;
        }
    }

    private void SetState(eState newState)
    {
        m_state = newState;
        m_stateTime = 0f;

        switch (m_state)
        {
            case eState.ScrollingText:
                {
                    SetColorAlpha(infoDescription, 1);

                    if (m_targetScrollTextCount == 0)
                    {
                        SetState(eState.Idle);
                        return;
                    }
                }
                break;
        }
    }

    private void SetColorAlpha(MaskableGraphic graphic, float a)
    {
        Color col = graphic.color;
        col.a = a;
        graphic.color = col;
    }
}

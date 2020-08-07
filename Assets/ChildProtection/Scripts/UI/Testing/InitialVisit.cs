using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVisit : MonoBehaviour
{

    public ReactionCollection reaction;
    //bool tutorialHasPlayed = false;

    ReliefProjectTracker pTracker;

    //// Start is called before the first frame update
    //void Awake()
    //{
    //    if (Instance != null) { Destroy(gameObject); return; } // stops dups running
    //    DontDestroyOnLoad(gameObject); // keep me forever
    //    Instance = this; // set the reference to it 
    //}

    private void Awake()
    {
        pTracker = GameObject.FindObjectOfType<ReliefProjectTracker>();
    }

    private void Start()
    {

        if (!pTracker.tutorialHasPlayed)
        {
            StartCoroutine(WaitToStartTutorial());
            pTracker.tutorialHasPlayed = true;
        }     
    }

    IEnumerator WaitToStartTutorial()
    {
        yield return new WaitForSeconds(0.25f);
        reaction.React();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVisit : MonoBehaviour
{
    public ReactionCollection reaction;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToStartTutorial());
    }

    IEnumerator WaitToStartTutorial()
    {
        yield return new WaitForSeconds(0.25f);
        reaction.React();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVillageVisit : MonoBehaviour
{
    public ReactionCollection reaction;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(WaitToStartTutorial());
    }

    IEnumerator WaitToStartTutorial()
    {
        yield return new WaitForSeconds(0.25f);
        reaction.React();
    }
}

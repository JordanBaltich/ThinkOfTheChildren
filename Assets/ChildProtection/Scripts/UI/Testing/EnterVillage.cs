using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVillage : MonoBehaviour
{
    public ReactionCollection reaction;

    // Start is called before the first frame update
    void Start()
    {
        reaction.React();
    }
}

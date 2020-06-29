using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitABitHolder : MonoBehaviour
{
    public PlayerMovement pm;

    public void WaitForABit()
    {
        StartCoroutine("WaitingForABit", pm.AcceptingOnMove);
    }

    IEnumerator WaitingForABit(bool b)
    {
        yield return new WaitForSeconds(1f);
        b = true;
    }
}

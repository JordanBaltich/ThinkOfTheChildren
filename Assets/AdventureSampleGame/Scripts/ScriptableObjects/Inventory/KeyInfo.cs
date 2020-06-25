using UnityEngine;

// This simple script represents KeyInfo that can written 
// in the journal.  The journal system is done using
// this script instead of just strings to ensure that info
// are extensible.
[CreateAssetMenu]
public class KeyInfo : ScriptableObject
{
    public string Description;
}

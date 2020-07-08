using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportIcon : MonoBehaviour
{
    private void OnEnable()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayUIClip(0);
        }
    }
}

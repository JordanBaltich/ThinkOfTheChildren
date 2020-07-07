using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebuildObject : MonoBehaviour
{
    [SerializeField] GameObject rebuildPrefab, destroyedPrefab;
    public bool isFixed = false;

    [SerializeField] int neededPoints = 1;

    private void Awake()
    {
        DestroyTheObject();
    }

    public void CheckForNeededPoints(PointsSystem pointsSystem)
    {
        if (pointsSystem.currentPoints >= neededPoints)
        {
            RebuildTheObject();
            pointsSystem.SpendPoints(neededPoints);
        }
        else
        {
            print("Not Enough Points!");
        }
    }

    public void RebuildTheObject()
    {
        isFixed = true;
        rebuildPrefab.SetActive(true);
        destroyedPrefab.SetActive(false);
    }

    public void DestroyTheObject()
    {
        isFixed = false;
        rebuildPrefab.SetActive(false);
        destroyedPrefab.SetActive(true);
    } 
}

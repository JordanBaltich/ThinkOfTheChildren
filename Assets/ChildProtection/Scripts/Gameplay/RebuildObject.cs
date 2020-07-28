using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebuildObject : MonoBehaviour
{
    [SerializeField] GameObject rebuildPrefab, destroyedPrefab;
    public bool isFixed = false;

    [SerializeField] int neededPoints = 1;

    public int reliefProjectIndex;
    public string reliefProjectName;

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

    void CheckIfRebuilt()
    {
        if (GameObject.FindObjectOfType<ReliefProjectTracker>() != null)
        {
            ReliefProjectTracker tracker = GameObject.FindObjectOfType<ReliefProjectTracker>();

            if (tracker.projectStates[reliefProjectIndex])
            {
                RebuildTheObject();
            }
            else
            {
                DestroyTheObject();
            }
        }
    }

    public void AddProjectToTracker()
    {
        if (GameObject.FindObjectOfType<ReliefProjectTracker>() != null)
        {
            ReliefProjectTracker tracker = GameObject.FindObjectOfType<ReliefProjectTracker>();

            if (tracker.rebuildProjects.Count == 0)
            {
                tracker.AddProjectToTracker(reliefProjectName, isFixed);
                return;
            }
            else
            {
                for (int i = 0; i < tracker.rebuildProjects.Count; i++)
                {
                    if (tracker.rebuildProjects[i] == reliefProjectName)
                    {
                        return;
                    }
                    else if (i == tracker.rebuildProjects.Count - 1)
                    {
                        tracker.AddProjectToTracker(reliefProjectName, isFixed);
                        reliefProjectIndex = i + 1;
                        return;
                    }
                }
            }
        }
    }
}

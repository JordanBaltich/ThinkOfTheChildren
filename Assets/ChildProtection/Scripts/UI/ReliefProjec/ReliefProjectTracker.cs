using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefProjectTracker : MonoBehaviour
{
    public List<string> rebuildProjects;

    public List<bool> projectStates;

    public void AddProjectToTracker(string project, bool state)
    {
        rebuildProjects.Add(project);
        projectStates.Add(state);
    }


}

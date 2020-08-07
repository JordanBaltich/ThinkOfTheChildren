using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefProjectTracker : MonoBehaviour
{
    public List<string> rebuildProjects;

    public List<bool> projectStates;

    public bool tutorialHasPlayed = false;

    public void AddProjectToTracker(string project, bool state)
    {
        rebuildProjects.Add(project);
        projectStates.Add(state);
    }

    public void UpdateProjectState(string projectName, bool state)
    {
        string givenName = projectName;
        //check if name is in list
        if (rebuildProjects.IndexOf(givenName) != -1)
        {
            //get index of listed item
            int positionInList = rebuildProjects.IndexOf(givenName);
            //set item to given state
            projectStates[positionInList] = state;
        }
    }
}

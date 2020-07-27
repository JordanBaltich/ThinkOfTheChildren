using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReliefProjectController : MonoBehaviour
{
    [Header("Choices")]
    public GameObject choicesHolder;
    [SerializeField] string choicesHolderName = "Choices";
    public List<GameObject> choices;

    [Header("Status")]
    public GameObject statBarHolder;
    [SerializeField] string statBarHolderName = "Status Bars";
    public List<StatusBar> stats;

    [Header("Info")]
    public List<GameObject> info;

    private void Awake()
    {
        // find stat bar holder and get a reference to each bar
        statBarHolder = GameObject.Find(statBarHolderName);
        foreach (RectTransform rt in statBarHolder.GetComponentInChildren<RectTransform>())
        {
            StatusBar currentbar = rt.GetComponent<StatusBar>();
            stats.Add(currentbar);
        }

        //find choices holder and get reference to each choice
        choicesHolder = GameObject.Find(choicesHolderName);
        foreach (RectTransform rt in choicesHolder.GetComponentInChildren<RectTransform>())
        {
            GameObject currentChoice = rt.gameObject;
            choices.Add(currentChoice);
        }
        // remove first reference in array as it is not a choice
        choices.RemoveAt(0);

    }

    private void OnEnable()
    {

        OnlyShowFoundProjects();
    }

    void OnlyShowFoundProjects()
    {
        ReliefProjectTracker tracker = GameObject.FindObjectOfType<ReliefProjectTracker>();

        for (int i = 0; i < choices.Count; i++)
        {
            choices[i].GetComponent<Button>().interactable = false;
            for (int ii = 0; ii < tracker.rebuildProjects.Count; ii++)
            {
                if (choices[i].GetComponent<OptionButton>().choiceName == tracker.rebuildProjects[ii])
                {
                    choices[i].GetComponent<Button>().interactable = true;
                }
            }
        }
    }

}

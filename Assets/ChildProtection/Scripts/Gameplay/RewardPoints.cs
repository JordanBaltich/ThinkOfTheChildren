using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardPoints : MonoBehaviour
{
    [SerializeField] GameObject endGameObject;

    public void GivePointsBasedOnReport()
    {
        Report report = GameObject.FindObjectOfType<Report>();
        PointsSystem pSystem = GameObject.FindObjectOfType<PointsSystem>();

        //if this is the first report handed in
        if (pSystem.keyInfos.Count == 0)
        {
            //add report items to list and reward points
            for (int i = 0; i < report.keyInfos.Length; i++)
            {
                if (report.keyInfos[i] != null)
                {
                    pSystem.keyInfos.Add(report.keyInfos[i]);
                    pSystem.AddPoints(2);
                }
            }
        }
        else
        {
            for (int i = 0; i < report.keyInfos.Length; i++)
            {
                //find report slots that are not empty
                if (report.keyInfos[i] != null)
                {
                    //check if the report has already been handed in
                    if (pSystem.keyInfos.Contains(report.keyInfos[i]))
                    {
                        return;
                    }
                    //if not handed in, collect and reward points
                    else
                    {
                        pSystem.keyInfos.Add(report.keyInfos[i]);
                        pSystem.AddPoints(2);
                    }
                }
            }
        }

        EndTheGame();
    }

    public void EndTheGame()
    {
        PointsSystem pSystem = GameObject.FindObjectOfType<PointsSystem>();
        if (pSystem.keyInfos.Count == 3)
        {
            print(pSystem.keyInfos.Count);

            endGameObject.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public List<KeyInfo> keyInfos;
    public int totalPoints, currentPoints, spentPoints;

    private void Start()
    {
        totalPoints = currentPoints;
    }

    public void AddPoints(int addedPoints)
    {
        totalPoints += addedPoints;
        currentPoints += addedPoints;
    }

    public void SpendPoints(int pointsSpent)
    {
        currentPoints -= pointsSpent;
    }

    public void EndTheGame()
    {
        if (keyInfos.Count == 3)
        {
            if (GameObject.Find("EndGameTrigger") != null)
            {
                GameObject endGameObject = GameObject.Find("EndGameTrigger");
                endGameObject.SetActive(true);
            }
        }
    }
}

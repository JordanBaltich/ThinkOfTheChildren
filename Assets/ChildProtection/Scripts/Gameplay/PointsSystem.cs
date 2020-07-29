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

}

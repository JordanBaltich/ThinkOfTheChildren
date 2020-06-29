using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public int totalPoints, currentPoints, spentPoints;

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

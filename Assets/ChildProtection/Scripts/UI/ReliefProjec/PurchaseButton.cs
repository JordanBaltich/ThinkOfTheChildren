using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{
    public OptionButton currentSelection;
    Button m_Button;

    [SerializeField]PointsSystem pointsSystem;

    [SerializeField] GameObject NotEnoughPointsPanel;

    private void Awake()
    {
        m_Button = GetComponent<Button>();
        pointsSystem = GameObject.FindObjectOfType<PointsSystem>();
    }

    private void Start()
    {
        m_Button.interactable = false;
    }


    public void ClearSeletion()
    {
        currentSelection = null;
        m_Button.interactable = false;
    }

    public void AssignSelected(OptionButton selectedOption)
    {
        currentSelection = selectedOption;
        m_Button.interactable = true;
    }

    public void Purchase()
    {
        if (currentSelection != null)
        {
            if (HasEnoughPoints())
            {
                currentSelection.ConfirmPointsSpent();
                pointsSystem.SpendPoints(currentSelection.cost);
                GameObject.FindObjectOfType<ReliefProjectTracker>().UpdateProjectState(currentSelection.choiceName, true);
                m_Button.interactable = false;
                currentSelection.GetComponent<Button>().interactable = false;
                currentSelection = null;
               

               
            }
            else
            {
                NotEnoughPointsPanel.SetActive(true);
            }
        }
    }

    bool HasEnoughPoints()
    {
        if (pointsSystem.currentPoints >= currentSelection.cost)
        {
            return true;
        }
        else return false;
    }
}

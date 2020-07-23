using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionButton : MonoBehaviour
{
    TextMeshProUGUI m_ButtoText;

    [Header("Info")]
    public string choiceName;
    public int cost;
    [SerializeField] string description;
    [SerializeField] Sprite optionImage;
    public float[] improvements = new float[5];

    [Header("UI References")]
    [SerializeField] string nameTextObjectName;
    public TextMeshProUGUI nameText;
    [SerializeField] string costTextObjectName;
    public TextMeshProUGUI costText;
    [SerializeField] string descriptionObjectName;
    public TextMeshProUGUI descriptionText;
    [SerializeField] string uiImageObjectName;
    public Image uiImage;

    ReliefProjectController rpController; 

    private void Awake()
    {
        m_ButtoText = GetComponentInChildren<TextMeshProUGUI>();

        nameText = GameObject.Find(nameTextObjectName).GetComponent<TextMeshProUGUI>();
        costText = GameObject.Find(costTextObjectName).GetComponent<TextMeshProUGUI>();
        descriptionText = GameObject.Find(descriptionObjectName).GetComponent<TextMeshProUGUI>();
        uiImage = GameObject.Find(uiImageObjectName).GetComponent<Image>();

        rpController = GameObject.FindObjectOfType<ReliefProjectController>();
    }

    private void Start()
    {
        m_ButtoText.text = choiceName;
    }

    public void UpdateInfoOnClick()
    {
        nameText.text = choiceName;
        costText.text = cost.ToString();
        descriptionText.text = description;
        uiImage.sprite = optionImage;

        for (int i = 0; i < rpController.stats.Count; i++)
        {
            rpController.stats[i].ShowImprovement(improvements[i]);
        }
    }

    public void ConfirmPointsSpent()
    {
        for (int i = 0; i < rpController.stats.Count; i++)
        {
            rpController.stats[i].FillBar(improvements[i]);
        }
    }
}

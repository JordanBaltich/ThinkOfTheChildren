using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkToMap : MonoBehaviour
{
    [SerializeField] Transform linkedTransform;

    [SerializeField] string linkedObjectName;
    [SerializeField] Sprite Icon;
    RectTransform myRectTransform;
    Image myImage;

    private void Awake()
    {
        //myRectTransform = GetComponent<RectTransform>();
        //myImage = GetComponent<Image>();
        //linkedTransform = GameObject.Find(linkedObjectName).transform;
        //myRectTransform.position = new Vector3(linkedTransform.position.x, linkedTransform.position.z, 0);
    }

    private void Start()
    {
        myImage.sprite = Icon;
        myRectTransform.position = new Vector3(linkedTransform.position.x, linkedTransform.position.z, 0);
    }

    private void OnEnable()
    {
        myRectTransform = GetComponent<RectTransform>();
        myImage = GetComponent<Image>();
        linkedTransform = GameObject.Find(linkedObjectName).transform;
        myRectTransform.position = new Vector3(linkedTransform.position.x, linkedTransform.position.z, 0);
    }

    private void Update()
    {
        myRectTransform.localPosition = new Vector3(linkedTransform.position.x, linkedTransform.position.z, 0);
    }
}

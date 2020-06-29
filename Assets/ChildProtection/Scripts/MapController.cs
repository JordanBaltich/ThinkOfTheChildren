using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField] float scaleSpeed, maxScale, minScale, mouseDragSpeed;
    RectTransform myRectTransform;
    [SerializeField] RectTransform playerIconPosition;
    private void Awake()
    {
        myRectTransform = GetComponent<RectTransform>();

    }

    // Start is called before the first frame update
    void Start()
    {
        myRectTransform.localScale = Vector3.one * minScale;
    }

    private void OnEnable()
    {
        myRectTransform.localPosition = playerIconPosition.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.mouseScrollDelta.y != 0)
        {
            myRectTransform.localScale += Vector3.one * (Input.mouseScrollDelta.y * scaleSpeed) * Time.unscaledDeltaTime;

            if (myRectTransform.localScale.x >= maxScale)
            {
                myRectTransform.localScale = Vector3.one * maxScale;
            }
            if (myRectTransform.localScale.x <= minScale)
            {
                myRectTransform.localScale = Vector3.one * minScale;
            }
        }

        if (Input.GetMouseButton(0))
        {
            float hor = Input.GetAxis("Mouse X");
            float vert = Input.GetAxis("Mouse Y");

            Vector3 inputDirection = new Vector3(hor, vert, 0);

            myRectTransform.position += inputDirection * mouseDragSpeed;
        }

    }
}

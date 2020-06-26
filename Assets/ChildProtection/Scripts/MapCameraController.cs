using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MapCameraController : MonoBehaviour
{
    [SerializeField] float scaleSpeed, maxScale, minScale, mouseDragSpeed;
    RectTransform myRectTransform;
    [SerializeField] Transform playerIconPosition;

    CinemachineVirtualCamera myCamera;

    private void Awake()
    {
        myCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        transform.position = new Vector3(playerIconPosition.position.x, transform.position.y, playerIconPosition.position.z);
        StopTime(true);
    }

    private void OnDisable()
    {
        StopTime(false);
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.mouseScrollDelta.y);

        if (Input.mouseScrollDelta.y != 0)
        {
            myCamera.m_Lens.FieldOfView += -Input.mouseScrollDelta.y * scaleSpeed * Time.unscaledDeltaTime;

            myCamera.m_Lens.FieldOfView = Mathf.Clamp(myCamera.m_Lens.FieldOfView, minScale, maxScale);
        }

        if (Input.GetMouseButton(0))
        {
            float hor = Input.GetAxis("Mouse X");
            float vert = Input.GetAxis("Mouse Y");

            Vector3 inputDirection = new Vector3(hor, 0, vert);

            transform.position += inputDirection * mouseDragSpeed * Time.unscaledDeltaTime;
        }
    }

    public void StopTime(bool timeStopped)
    {
        if (timeStopped)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
}

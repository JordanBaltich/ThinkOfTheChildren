using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MapCameraController : MonoBehaviour
{
    [SerializeField] float scaleSpeed, maxScale, minScale, mouseDragSpeed, keyPressMoveSpeed;
    RectTransform myRectTransform;
    [SerializeField] Transform playerIconPosition;

    Camera OrthoCamera;

    private void Awake()
    {
        OrthoCamera = GetComponentInChildren<Camera>();
    }

    private void OnEnable()
    {
        CentreToPlayer();

        // stop time and play music clip
        StopTime(true);

        if(AudioManager.Instance != null)
            AudioManager.Instance.PlayMusicClip(0);
    }

    private void OnDisable()
    {
        // restart time and stop music
        StopTime(false);
        if (AudioManager.Instance != null)
            AudioManager.Instance.StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        #region Mouse Inputs
        //if mouse wheel is being scrolled, scale camera size in direction wheel is being scrolled.
        if (Input.mouseScrollDelta.y != 0)
        {
            OrthoCamera.orthographicSize += -Input.mouseScrollDelta.y * scaleSpeed * Time.unscaledDeltaTime;

            OrthoCamera.orthographicSize = Mathf.Clamp(OrthoCamera.orthographicSize, minScale, maxScale);
        }

        // while left mouse button is held, move map in diretion of mouse drag.
        if (Input.GetMouseButton(0))
        {
            float hor = Input.GetAxis("Mouse X");
            float vert = Input.GetAxis("Mouse Y");

            Vector3 inputDirection = new Vector3(hor, 0, vert);

            transform.position += inputDirection * mouseDragSpeed * Time.unscaledDeltaTime;
        }

        //recentre to player positon on map
        if (Input.GetMouseButtonDown(1))
        {
            CentreToPlayer();
        }
        #endregion

        #region Keyboard Inputs
        //move camera in direction given through key press
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude != 0)
        {
            transform.position -= direction * keyPressMoveSpeed * Time.unscaledDeltaTime;
        }       

        //recentre to player positon on map
        if (Input.GetButtonDown("Jump"))
        {
            CentreToPlayer();
        }
        #endregion
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

    void CentreToPlayer()
    {
        if (playerIconPosition == null)
        {
            if (GameObject.FindObjectOfType<PlayerMovement>() != null)
            {
                playerIconPosition = GameObject.FindObjectOfType<PlayerMovement>().transform;
            }
        }
        else
        {
            // centre camera to player's current position
            transform.position = new Vector3(playerIconPosition.position.x, transform.position.y, playerIconPosition.position.z);
        }
       
    }
}

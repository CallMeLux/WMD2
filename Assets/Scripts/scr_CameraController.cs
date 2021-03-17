using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public GameObject playerBody;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       
       float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

       xRotation -= mouseY;
       yRotation += mouseX;
       xRotation = Mathf.Clamp(xRotation, -90f, 90f);
       //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       //playerBody.transform.Rotate(Vector3.up * mouseX);

       if (playerBody.GetComponent<scr_PlayerController>().catchModeOn)
       {
           transform.localRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z);
           playerBody.transform.Rotate(0f,0f,0f);
       }
       else
       {
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //playerBody.transform.Rotate(Vector3.up * mouseX);
        playerBody.transform.Rotate(Vector3.up * mouseX);
       }

    }
}

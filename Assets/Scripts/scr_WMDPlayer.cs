using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_WMDPlayer : MonoBehaviour
{
 // movement
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject PauseCanvas;
    public GameObject MainCamera;
    public bool isPaused = false;
    Vector3 velocity;
    bool isGrounded;
    // inflatable pants mechanic
    public bool isfloating;
    public float floatStrength = 3.5f;
    //public float heat = 0;
    //public float cold;

    public Animator p_animator;

    void Start()
    {
        
        // getting components
        controller = GetComponent<CharacterController>();
        // float mechanic
        isfloating = false;
        MainCamera.gameObject.SetActive(true); 

        Time.timeScale = 1;  

        GetComponent<scr_CatchMode>();
        
    }
        void Update()
    {
        
        //Pausing
        if (Input.GetButtonDown("Cancel") && isPaused == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
            isPaused = true;
        }
        
        else if (Input.GetButtonDown("Cancel") && isPaused == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            PauseCanvas.SetActive(false);
            isPaused = false;
        }
        
        // movement  
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = Camera.main.transform.right * x + Camera.main.transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
            p_animator.SetBool("isRunning", true);
        }
        else
        {
            p_animator.SetBool("isRunning", false);
        }
}
}
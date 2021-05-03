using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BlobfishingPlayerController : MonoBehaviour
{
    // movement
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask houseFloorMask;
    public GameObject PauseCanvas;
    public GameObject MainCamera;
    public bool isPaused = false;
    Vector3 velocity;
    bool isGrounded;
    // inflatable pants mechanic
    public bool isfloating;
    public float floatStrength = 3.5f;

    // catchmode
    [SerializeField]
    GameObject pants;
    [SerializeField]
    GameObject ipants;


    public Animator p_animator;
    public Animator pants_animator;

    void Start()
    {
        
        // getting components
        controller = GetComponent<CharacterController>();
        // float mechanic
        isfloating = false;
        pants_animator.SetBool("isInflated", false);

        Time.timeScale = 1;

        MainCamera.gameObject.SetActive(true);   

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

        // pants mechanic
        if (!isfloating)
        {
        pants_animator.SetBool("isInflated", false);

        if (Input.GetButtonDown("Fire3"))
        {
            isfloating = true;
            Debug.Log("is floating = " + isfloating);
        }
        }
        else if (isfloating)
        {
        pants_animator.SetBool("isInflated", true);
        if(Input.GetButtonDown("Fire3"))
        {
            isfloating = false;
            Debug.Log ("is floating = " + isfloating);
        }    
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(floatStrength * -2f * gravity);
        }
        }
        if (isfloating == false)
        {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
            //playerBody.transform.Rotate(0f,Camera.main.transform.rotation.y,0f);
            //transform.localRotation = Quaternion.Euler(0f, Camera.main.transform.forward, 0f);
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && isGrounded)
        {
            
            p_animator.SetBool("isRunning", true);
            ipants.SetActive(false);
            pants.SetActive(true);

        }
        else
        {
            ipants.SetActive(true);
            pants.SetActive(false);
            p_animator.SetBool("isRunning", false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        scr_NpcTalk npctalk = this.GetComponent<scr_NpcTalk>();
        if (other.tag == "Rings")
        {
            npctalk.SetCoinText(1);
            npctalk.SetRingText(1);
            Destroy(other.gameObject);
            Debug.Log("working");
        }
    }
}

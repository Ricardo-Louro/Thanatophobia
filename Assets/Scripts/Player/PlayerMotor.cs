using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    
    public AudioSource source;
    public AudioClip clip;

    private bool sprinting;
    private bool isGrounded;
    public float speed = 0f;
    private float gravity = 0;
    private float timer = 0f;
    private bool trigger = false;
    private float startVolume; 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        source.clip = clip;
        startVolume = source.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(timer >= 32f)
        {
            gravity = -9.5f;
        }
        else
        {
            timer += Time.deltaTime;
        }
        
        isGrounded = controller.isGrounded;

        if(isGrounded && (speed > 0f) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            if (trigger)
            {}
            else
            {
                trigger = true;
                source.Play();
            }
        }
        else
        {
            trigger = false;
            while (source.volume > 0)
            {
                source.volume -= 0.00001f;
            }
            source.Stop();
            source.volume = startVolume; 
        }
    }

    //Receive inputs from our InputManager script and and apply them to our character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
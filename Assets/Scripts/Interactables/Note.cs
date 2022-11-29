using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : Interactable
{
    [SerializeField]
    private Image customImage;
    [SerializeField]
    private Image Note_Back;
    private bool Trigger = false;
    public bool Movement_Restriction = false;

    public PlayerMotor PlayerMotor;
    public PlayerLook PlayerLook;

    
    // Start is called before the first frame update
    void Start()
    {
        Note_Back.enabled = false;
        customImage.enabled = false;
    }

    protected override void Interact()
    {
        if (Trigger == false)
        {
            Note_Back.enabled = true;
            customImage.enabled = true;
            Trigger = true;
            PlayerMotor.speed = 0f;
            PlayerLook.ySensitivity = 0f;
            PlayerLook.xSensitivity = 0f;
        }
        else
        {
            Note_Back.enabled = false;
            customImage.enabled = false;
            Trigger = false;
            PlayerMotor.speed = 5f;
            PlayerLook.xSensitivity = 10f;
            PlayerLook.ySensitivity = 10f;
        }
    }
}

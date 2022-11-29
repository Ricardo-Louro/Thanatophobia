using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oblivion_Trigger : MonoBehaviour
{
    [SerializeField]
    public PlayerMotor PlayerMotor;
    public PlayerLook PlayerLook;
    [SerializeField]
    private Image Oblivion_Black;
    
    // Start is called before the first frame update
    void Start()
    {
        Oblivion_Black.enabled = false;
    }

    void OnTriggerEnter()
    {
        Oblivion_Black.enabled = true;
        PlayerMotor.speed = 0f;
        PlayerLook.ySensitivity = 0f;
        PlayerLook.xSensitivity = 0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision_Trigger : MonoBehaviour
{
    [SerializeField]
    public PlayerMotor PlayerMotor;
    public PlayerLook PlayerLook;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerMotor.speed = 0f;
        PlayerLook.ySensitivity = 0f;
        PlayerLook.xSensitivity = 0f;
    }

    void OnTriggerEnter()
    {
        PlayerMotor.speed = 5f;
        PlayerLook.xSensitivity = 10f;
        PlayerLook.ySensitivity = 10f;
    }
}

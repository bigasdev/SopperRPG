using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller))]
public class Player : MonoBehaviour
{
    Controller controller;
    void Start()
    {
        controller = GetComponent<Controller>(); 
    }

}

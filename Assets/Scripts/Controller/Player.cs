using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller))]
public class Player : MonoBehaviour
{
    float gravity = 50;
    int moveSpd = 5;
    Vector3 velocity;
    
    Controller controller;
    void Start()
    {
        controller = GetComponent<Controller>(); 
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        velocity.x = input.x * moveSpd;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}

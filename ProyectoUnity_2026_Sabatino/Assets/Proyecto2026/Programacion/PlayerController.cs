using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    #region CORE

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        Update_MovimientoPlayer();
        
    }
    #endregion CORE 

    #region MOVIMIENTO
    private float horizontalMove;
    private float verticalMove;

    public CharacterController player;

    [Header("Movimiento")]

    public float PlayerSpeed = 5f;

    private void Update_MovimientoPlayer()
    {
        //Movimiento basico
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        //Movimiento diagonal, se estabiliza la velociadad de Horizontal y vertical con el Normalized
        Vector3 move = transform.right * horizontalMove + transform.forward * verticalMove;

        move.Normalize();

        SetGravity();
        PlayerSkills();


        Vector3 finalMove = move * PlayerSpeed + velocity;

        player.Move(finalMove * Time.deltaTime);
    }

    #region GRAVEDAD

    public float gravity = -9.8f;

    private Vector3 velocity;

    void SetGravity()
    {
        if (player.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        

        velocity.y += gravity * Time.deltaTime;
    }

    #endregion GRAVEDAD

    #endregion MOVIMIENTO

    #region SALTO

    public float jumpHeight = 2f;

    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    #endregion



}





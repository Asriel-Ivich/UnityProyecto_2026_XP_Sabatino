using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;

    public CharacterController player;

    public float playerSpeed = 5f;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalMove, 0, verticalMove).normalized;

        player.Move(move * playerSpeed * Time.deltaTime);

    }
}

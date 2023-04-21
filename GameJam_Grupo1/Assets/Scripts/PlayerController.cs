using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Control del jugador
    private float horizontalInput;
    private float verticalInput;
    private Vector3 _moveVector;

    // Características dle jugador
    private float speed = 5;
    public Rigidbody playerRB;

    // Variables de estado
    private bool isOnGround;    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        _moveVector = Vector3.zero;
        _moveVector.x = horizontalInput * speed * Time.deltaTime;
        _moveVector.z = verticalInput * speed * Time.deltaTime;

        //Movement + rotation code from -> https://youtu.be/HVTQ-VJCbws

        Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);
        playerRB.MovePosition(playerRB.position + _moveVector);

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playerRB.AddForce(Vector3.up * 300, ForceMode.Impulse);
            isOnGround = false;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        isOnGround = true;
    }

}
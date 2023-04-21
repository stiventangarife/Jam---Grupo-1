using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Control del jugador
    private float horizontalInput;
    private float verticalInput;
    private Vector3 _moveVector;

    // Características del jugador
    private float speed = 2;
    public Rigidbody playerRB;

    // Variables de estado
    private bool isOnGround;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
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

        if(horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playerRB.AddForce(Vector3.up * 250, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump");
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        isOnGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }

}
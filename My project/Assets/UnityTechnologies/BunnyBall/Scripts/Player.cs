using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cameraTransform;
    public GameManager gameManager;
    public float speed = 10f;
    public int jumpforce = 100;
    private int x = 0;
    private bool isGrounded = false;

    void Update()
    {
        x = x + 1;
        //Debug.Log(message: "Hello" + x);
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        Vector3 direction = forward * moveVertical + right * moveHorizontal;
        rb.AddForce(direction * speed);

        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded == true)
        {
            Debug.Log("Space was pressed");
            rb.AddForce(Vector3.up * jumpforce);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pular : MonoBehaviour
{
    public string estado;
    public string AR = "ar";
    public string CHAO = "chao";

    private float jumpTimeCounter;
    public float jumpTime;
    public float jumpForce;
    private bool isJumping;
    private float moveInput;
    public bool nochao;
    public AudioSource audioSource;

    private Rigidbody2D rb;
    public GameObject Player;
    public bool Interact;

    public bool shoted;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Interact == false)
        {
            if (shoted && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else { isJumping = false; }
            }

            if (!shoted)
            {
                isJumping = false;
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        shoted = context.action.triggered;

        if (Interact == false)
        {
            if (shoted && estado == CHAO)
            {
                audioSource.Play();
                isJumping = true;
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter = jumpTime;
            }
        }
    }
}
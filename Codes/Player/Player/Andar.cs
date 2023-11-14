using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Andar : MonoBehaviour
{
    public float moveSpeed;
    private float moveInput;
    private float moveInputY;
    public float axis;
    public float axisy;

    public bool ladoDireito = true;
    public bool ladoCima = true;

    public Rigidbody2D rb;
    private Animator animator;
    public Transform spritePlayer;
    public GameObject Player;

    public float horizontal;
    public float vertical;
    public Vector2 direction;
    public bool Interact;
    public float impulsepower;

    public ScaledMain scale;


    void Start()
    {
        scale = GetComponent<ScaledMain>();
        rb = GetComponent<Rigidbody2D>();
        animator = spritePlayer.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        animator.SetFloat("Velocity", Mathf.Abs(horizontal));
        animator.SetFloat("VelocityF", rb.velocity.y);

        if (scale.Scaled == false)
        {
            transform.right = new Vector3(0, 0, 0);
            axis = horizontal;
            axisy = vertical;

            moveInput = horizontal;
            moveInputY = vertical;

            if (axis > 0 && !ladoDireito)
                Vire();
            if (axis < 0 && ladoDireito)
                Vire();

            if (axis > 0 || axis < 0)
            { 
                rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
                StartCoroutine("Stop");
            }

            if (horizontal != 0f || vertical != 0f)
            {
                direction = new Vector2(horizontal, vertical);
            }
        }
        else
        {
            rb.AddForce(direction * impulsepower, ForceMode2D.Impulse);
            scale.Scaled = false;
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void Vire()
    {
        ladoDireito = !ladoDireito;
        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.localScale = novoScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
}
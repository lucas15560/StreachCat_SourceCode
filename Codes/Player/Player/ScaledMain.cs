using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScaledMain : MonoBehaviour
{
    public float[] LimitMax;
    public float[] LimitMin;
    public SpriteRenderer sr;
    public BoxCollider2D[] bc;

    public bool shoted;
    public float Velocity;
    public bool Scaled;

    private Andar andar;
    private Rigidbody2D rb;
    public AudioSource audioSource;

    public bool LimiteArea;

    void Start()
    {
        andar = GetComponent<Andar>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (shoted && sr.size.x <= LimitMax[0] && !LimiteArea)
        {
            if (andar.ladoDireito == true)
            {
                sr.size += new Vector2(Velocity * andar.direction.x, 0);
                bc[0].size += new Vector2(Velocity * andar.direction.x, 0);
                bc[1].size += new Vector2(Velocity * andar.direction.x, 0);
            }
            else
            {
                sr.size += new Vector2(-Velocity * andar.direction.x, 0);
                bc[0].size += new Vector2(-Velocity * andar.direction.x, 0);
                bc[1].size += new Vector2(-Velocity * andar.direction.x, 0);
            }
        }
        else
        {
            if(!shoted || !shoted && !LimiteArea)
            {
                StartCoroutine("Scaleed");
            }
        }

        if (shoted && sr.size.y <= LimitMax[1] && !LimiteArea)
        {
            if(andar.direction.y > 0)
            {
                sr.size += new Vector2(0, Velocity * andar.direction.y);
                bc[0].size += new Vector2(0, Velocity * andar.direction.y);
                bc[1].size += new Vector2(0, Velocity * andar.direction.y);
            }
        }
        else
        {
            if (!shoted || !shoted && !LimiteArea)
            {
                StartCoroutine("Scaleed");
            }
        }
    }

    IEnumerator Scaleed()
    {
        yield return new WaitForSeconds(1.0f);

        if (!shoted && sr.size.y > LimitMin[1])
        {
            sr.size += new Vector2(0, -0.2f);
            bc[0].size += new Vector2(0, -0.2f);
            bc[1].size += new Vector2(0, -0.2f);

            if(sr.size.y <= LimitMin[1])
            {
                audioSource.Play();
                Scaled = true;
            }
        }

        if (!shoted && sr.size.x > LimitMin[0])
        {
            sr.size += new Vector2(-0.2f, 0);
            bc[0].size += new Vector2(-0.2f, 0);
            bc[1].size += new Vector2(-0.2f, 0);

            if (sr.size.x <= LimitMin[1])
            {
                audioSource.Play();
                Scaled = true;
            }
        }
    }

    public void Shot(InputAction.CallbackContext context)
    {
        shoted = context.action.triggered;
    }
}

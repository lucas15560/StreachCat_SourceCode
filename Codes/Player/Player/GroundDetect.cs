using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetect : MonoBehaviour
{
    public Pular pular;
    public Rigidbody2D rb;
    public GameObject Player;
    private Animator animator;
    public Transform spritePlayer;
    public GameObject Bah;

    public string estado;
    public string AR = "ar";
    public string CHAO = "chao";
    public bool nochao;

    void Start()
    {
        pular = Player.GetComponent<Pular>();
        rb = Player.GetComponent<Rigidbody2D>();
        animator = spritePlayer.GetComponent<Animator>();
    }

    void Update()
    {
        pular.estado = estado;
        pular.AR = AR;
        pular.CHAO = CHAO;
        pular.nochao = nochao;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Cadeado")
        {
            Instantiate(Bah, this.transform.position, this.transform.rotation);
            nochao = true;
            estado = CHAO;
            animator.SetBool("NoChao", true);
        }

        if (collision.gameObject.tag == "Monster")
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(transform.up * 6, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Cadeado")
        {
            nochao = false;
            estado = AR;
            animator.SetBool("NoChao", false);
        }
    }
}

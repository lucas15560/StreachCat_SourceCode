using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetFish : MonoBehaviour
{
    public int thislevel;
    public GameObject Bah;
    public GameObject Bah2;
    public int Peixes;
    public int TotalP;
    public string Scene;
    public AudioSource audioSource;
    public AudioSource audioSource2;

    private Animator animator;
    public Transform spritePlayer;
    public SpriteRenderer spriteRenderer;
    public LevelUnlock levelunlock;

    void Start()
    {
        levelunlock = GetComponent<LevelUnlock>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        animator = spritePlayer.GetComponent<Animator>();
    }

    void Update()
    {
        if(Peixes >= TotalP)
        {
            Peixes = 0;
            StartCoroutine("Bruh");
        }
    }

    IEnumerator Bruh()
    {
        if(levelunlock.Sla2 < thislevel)
        {
            levelunlock.Sla = true;
        }
        yield return new WaitForSeconds(1.0f);
        animator.Play("CutOn");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(Scene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            Instantiate(Bah, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            audioSource.Play();
            Peixes++;
        }

        if (collision.gameObject.tag == "Death")
        {
            StartCoroutine("Bruh2");
            audioSource2.Play();
            Instantiate(Bah2, this.transform.position, this.transform.rotation);
            this.spriteRenderer.enabled = false;
            transform.position = new Vector3(9999,9999,9999);
        }
    }

    IEnumerator Bruh2()
    {
        yield return new WaitForSeconds(1.0f);
        animator.Play("CutOn");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

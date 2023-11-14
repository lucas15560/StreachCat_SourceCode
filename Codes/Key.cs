using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool SelectLock;
    public GameObject Destoyer;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public GameObject Effect;
    public GameObject[] cadeado;
    public int Quantidade;
    private BoxCollider2D bc;

    public float time;

    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();

        if (!SelectLock)
        {
            cadeado = GameObject.FindGameObjectsWithTag("Cadeado");
            foreach (GameObject cadeado in cadeado)
            {
                Quantidade++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bc.enabled = false;
            audioSource2.Play();
            Destroy(Destoyer);
            sla();
        }
    }

    public void sla()
    {
        StartCoroutine("Stop");
        Quantidade--;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(time);

        if (Quantidade != -1)
        {
            Instantiate(Effect, cadeado[Quantidade].transform.position, cadeado[Quantidade].transform.rotation);
            audioSource.Play();
            Destroy(cadeado[Quantidade]);

            sla();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

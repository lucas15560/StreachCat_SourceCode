using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public GameObject Player;
    public Andar andar;
    public Vector2 direction2;
    public float speed;

    void Start()
    {
        andar = Player.GetComponent<Andar>();
    }

    void Update()
    {
        transform.localPosition = Player.transform.position;
        direction2 = new Vector2(andar.direction.x, andar.direction.y);

        float angle = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}

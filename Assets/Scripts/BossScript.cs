using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript: MonoBehaviour
{

    public GameObject boss_bee;
    public float speed = 2;
    public GameObject Player;
    private Rigidbody2D player_rb;
    private Rigidbody2D boss_rb;
    private Vector3 move;

    void Start()
    {
        boss_rb = GetComponent<Rigidbody2D>();
        player_rb = Player.GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        move = new Vector3(-1, 0, 0);

        if (boss_rb.transform.position.x > 0)
        {
            boss_rb.transform.position += move * speed * Time.deltaTime;
        }
    }
}

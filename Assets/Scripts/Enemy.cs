using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("이름")]
    [SerializeField]
    protected string enemyName = "";
    [Header("체력")]
    [SerializeField]
    protected int hp = 5;
    [Header("공격력")]
    [SerializeField]
    protected int damage = 1;
    [Header("이동속도")]
    [SerializeField]
    protected float moveSpeed = 1f;

    protected Vector2 direction = Vector2.zero;

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        name = enemyName;
    }


    void FixedUpdate()
    {
        ChasePlayer();
    }

    protected void ChasePlayer()
    {
        direction = (player.transform.position - transform.position) / (player.transform.position - transform.position).magnitude;

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    
}
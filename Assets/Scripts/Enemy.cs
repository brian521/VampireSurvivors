using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("�̸�")]
    [SerializeField]
    protected string enemyName = "";
    [Header("ü��")]
    [SerializeField]
    protected int hp = 5;
    [Header("���ݷ�")]
    [SerializeField]
    protected int damage = 1;
    [Header("�̵��ӵ�")]
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
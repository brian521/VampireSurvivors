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
 
    Rigidbody2D rigid;

    GameObject player;
    Weapon weapon;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // 리지드바디 가져오기

        player = GameObject.Find("Player");
        name = enemyName;
    }

    void Update()
    {
        if(hp <= 0)
        {
            HpZero();
        }
    }

    void FixedUpdate()
    {
        ChasePlayer();
    }

    protected void ChasePlayer()
    {
        direction = (player.transform.position - transform.position) / (player.transform.position - transform.position).magnitude; // 방향벡터 구하기

        rigid.MovePosition(rigid.position + (direction * moveSpeed * Time.deltaTime));
    }

    // 체력이 0일 때
    void HpZero() 
    {
        Destroy(gameObject);
    }

    // 무기에 닿으면 데미지 입기
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Weapon"))
        {
            weapon = col.collider.gameObject.GetComponent<Weapon>();
            
            hp -= weapon.damage;
        }
    }
}
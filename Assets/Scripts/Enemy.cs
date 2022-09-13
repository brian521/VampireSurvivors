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
 
    Rigidbody2D rigid;

    GameObject player;
    Weapon weapon;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // ������ٵ� ��������

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
        direction = (player.transform.position - transform.position) / (player.transform.position - transform.position).magnitude; // ���⺤�� ���ϱ�

        rigid.MovePosition(rigid.position + (direction * moveSpeed * Time.deltaTime));
    }

    // ü���� 0�� ��
    void HpZero() 
    {
        Destroy(gameObject);
    }

    // ���⿡ ������ ������ �Ա�
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Weapon"))
        {
            weapon = col.collider.gameObject.GetComponent<Weapon>();
            
            hp -= weapon.damage;
        }
    }
}
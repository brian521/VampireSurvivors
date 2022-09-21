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
    public int damage = 1;
    [Header("�̵��ӵ�")]
    [SerializeField]
    protected float moveSpeed = 1f;
    [Header("����ġ")]
    [SerializeField]
    protected GameObject gem;
    [Header("����")]
    [SerializeField]
    protected GameObject chest;


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
        int drop = Random.Range(0, 10);
        if (drop == 0)
        {
            Instantiate(chest, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(gem, transform.position, Quaternion.identity);
        }
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
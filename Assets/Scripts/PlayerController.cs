using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveX, moveY;

    Rigidbody2D rigid;

    [Header("�̵��ӵ� ����")]
    [SerializeField] // Inspector���� �����ϱ� ���ؼ� ���. public�� ����ص� ��
    [Range(1f, 10f)]
    float moveSpeed = 5f;
    

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // ������ٵ� ��������
    }

    void Update()
    {
        
    }

    void FixedUpdate() // �ַ� ����ȿ��(������ٵ�)�� ����� ������Ʈ�� ���
    {
        Move();
    }

    void Move()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        rigid.MovePosition(new Vector2(transform.position.x + moveX, transform.position.y + moveY));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveX, moveY;

    [Header("�̵��ӵ� ����")]
    [SerializeField] // Inspector���� �����ϱ� ���ؼ� ���. public�� ����ص� ��
    [Range(1f, 10f)]
    float moveSpeed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() // �ַ� ����ȿ���� ����� ������Ʈ�� ���
    {
        Move();
    }

    void Move()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }

}

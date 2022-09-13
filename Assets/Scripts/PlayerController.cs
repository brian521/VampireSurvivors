using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveX, moveY;

    Rigidbody2D rigid;

    public GameObject weapon;

    [Header("�̵��ӵ� ����")]
    [SerializeField] // Inspector���� �����ϱ� ���ؼ� ���. public�� ����ص� ��
    [Range(1f, 10f)]
    float moveSpeed = 5f;
    
    float nextAtkTime = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // ������ٵ� ��������
    }

    void Update()
    {
       StartCoroutine(Attack(weapon));
        FlipX();
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

    void FlipX()
    {
        if (moveX < 0)
        {
            transform.localScale = new Vector3(-0.75f, 0.75f, 1f);
        }
        else if (moveX > 0)
        {
            transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        }
    }

    // ���� ���� �Լ�
    IEnumerator Attack(GameObject weaponObject)
    {
        Weapon wp = weaponObject.GetComponent<Weapon>();
        GameObject summonedWeapon;

        if (nextAtkTime <= Time.time)
        {
            nextAtkTime += wp.atkDelay;

            if (transform.localScale.x < 0)
            {
                summonedWeapon = Instantiate(weaponObject, new Vector2(rigid.position.x - 2.04f, rigid.position.y + 0.6f), Quaternion.identity);
                summonedWeapon.transform.localScale = new Vector3(-3f, 3f, 1f);
            }
            else
            {
                summonedWeapon = Instantiate(weaponObject, new Vector2(rigid.position.x + 2.04f, rigid.position.y + 0.6f), Quaternion.identity);
                summonedWeapon.transform.localScale = new Vector3(3f, 3f, 1f);
            }

            yield return new WaitForSeconds(0.1f);
            summonedWeapon.GetComponent<SpriteRenderer>().material.color = new Color(1,1,1,0.5f);
            yield return new WaitForSeconds(0.1f);
            Destroy(summonedWeapon);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveX, moveY;

    Rigidbody2D rigid;

    public GameObject weapon;

    [Header("이동속도 조절")]
    [SerializeField] // Inspector에서 편집하기 위해서 사용. public을 사용해도 됨
    [Range(1f, 10f)]
    float moveSpeed = 5f;
    
    float nextAtkTime = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // 리지드바디 가져오기

        
    }

    void Update()
    {
       StartCoroutine(Attack(weapon));
    }

    void FixedUpdate() // 주로 물리효과(리지드바디)가 적용된 오브젝트에 사용
    {
        Move();
    }

    void Move()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        rigid.MovePosition(new Vector2(transform.position.x + moveX, transform.position.y + moveY));
    }

    // 무기 생성 함수
    IEnumerator Attack(GameObject weaponObject)
    {
        Weapon wp = weaponObject.GetComponent<Weapon>();
        
        if (nextAtkTime <= Time.time)
        {
            nextAtkTime += wp.atkDelay;
            GameObject summonedWeapon = Instantiate(weaponObject, new Vector2(rigid.position.x + 2.04f, rigid.position.y + 0.6f), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            summonedWeapon.GetComponent<SpriteRenderer>().material.color = new Color(1,1,1,0.5f);
            yield return new WaitForSeconds(0.1f);
            Destroy(summonedWeapon);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveX, moveY;

    [Header("이동속도 조절")]
    [SerializeField] // Inspector에서 편집하기 위해서 사용. public을 사용해도 됨
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

    void FixedUpdate() // 주로 물리효과가 적용된 오브젝트에 사용
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

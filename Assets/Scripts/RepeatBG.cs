using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    [Header("캐릭터")]
    [SerializeField]
    GameObject player;

    Vector2 playerpos;
    float distanceX, distanceY;

    void Update()
    {
        playerpos = player.transform.position;
        distanceX = transform.position.x - playerpos.x; // 배경타일과 플레이어 사이의 x 거리
        distanceY = transform.position.y - playerpos.y; // 배경타일과 플레이어 사이의 y 거리
    }

    void LateUpdate()
    {
        teleportX();
        teleportY();
    }

    // 배경타일의 X좌표 이동
    void teleportX()
    {
        if (distanceX > 20f)
        {
            transform.position = new (transform.position.x - 40f, transform.position.y);
        }
        else if (distanceX < -20f)
        {
            transform.position = new (transform.position.x + 40f, transform.position.y);
        }
    }

    // 배경타일의 Y좌표 이동
    void teleportY()
    {
        if(distanceY > 15f)
        {
            transform.position = new (transform.position.x, transform.position.y - 30f);
        }
        else if (distanceY < -15f)
        {
            transform.position = new (transform.position.x, transform.position.y + 30f);
        }
    }
}

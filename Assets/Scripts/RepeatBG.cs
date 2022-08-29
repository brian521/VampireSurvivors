using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    [Header("ĳ����")]
    [SerializeField]
    GameObject player;

    Vector2 playerpos;
    float distanceX, distanceY;

    void Update()
    {
        playerpos = player.transform.position;
        distanceX = transform.position.x - playerpos.x; // ���Ÿ�ϰ� �÷��̾� ������ x �Ÿ�
        distanceY = transform.position.y - playerpos.y; // ���Ÿ�ϰ� �÷��̾� ������ y �Ÿ�
    }

    void LateUpdate()
    {
        teleportX();
        teleportY();
    }

    // ���Ÿ���� X��ǥ �̵�
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

    // ���Ÿ���� Y��ǥ �̵�
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    float rot;
    Vector2 dir;

    void Start()
    {
        rot = transform.rotation.z;
        dir = Vector2.zero;
    }

    void Update()
    {
        if(rot%180 == 0)
        {
            dir = new Vector2((90 - rot) / 90, 0);
        } 
        else if(rot%90 == 0)
        {
            dir = new Vector2(0, rot / 90);
        }
        else if(rot<90 && rot>-90)
        {
            dir = new Vector2(1, rot / 45).normalized;
        }
        else
        {
            dir = new Vector2(-1, rot / 135).normalized;
        }

    }

    void FixedUpdate()
    {
        transform.Translate(dir * 0.2f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

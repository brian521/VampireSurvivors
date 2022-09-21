using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    int xp = 10;

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            PlayerController PC = col.GetComponent<PlayerController>();

            PC.currentXp += xp;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("공격력")]
    [SerializeField]
    public int damage = 2;

    [Header("공격 주기")]
    [SerializeField]
    public float atkDelay = 2f;
}

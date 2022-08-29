using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    GameObject[] Enemys;

    // Start is called before the first frame update
    void Start()
    {
        Enemys = Resources.LoadAll<GameObject>("Enemys/");
        SpawnBat();
        SpawnSkeleton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBat()
    {
        Instantiate(Enemys[0], new Vector2(10, 0), Quaternion.identity);
    }

    void SpawnSkeleton()
    {
        Instantiate(Enemys[1], new Vector2(0, 5), Quaternion.identity);
    }
}

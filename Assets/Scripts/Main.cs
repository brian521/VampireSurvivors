using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Main : MonoBehaviour
{
    [Header("웨이브")]
    [SerializeField]
    Wave[] waves;

    GameObject[] Enemys;
    GameObject player;

    Wave currentWave;
    int currentWaveNum = 0;
    float nextSpawntime = 0;
    float endOfWaveTime = 0;

    void Start()
    {
        Enemys = Resources.LoadAll<GameObject>("Enemys/");
        player = GameObject.Find("Player");

        NextWave();
    }

    void Update()
    {
        if (endOfWaveTime >= Time.time)
        {
            if (nextSpawntime <= Time.time) // 생성 주기에 따라 적 스폰
            {
                nextSpawntime += currentWave.spawnDelay;
                SpawnEnemy(currentWave.enemy);
            }
        }
        else if (currentWaveNum < waves.Length)
        {
            NextWave();
        }
    }

    // 다음 웨이브로 변경
    void NextWave()
    {
        currentWaveNum++;
        print("Wave: " + currentWaveNum);
        if (currentWaveNum - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNum - 1];
            endOfWaveTime += currentWave.spawnDelay * currentWave.enemyCount;
        }
    }

    public void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, player.transform.position + GetRandomVector(), Quaternion.identity);
    }

    // 랜덤 벡터를 생성 후 리턴
    private Vector3 GetRandomVector()
    {
        float radian = UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad;
        Vector3 spawnpoint;

        spawnpoint = new Vector3(15 * Mathf.Cos(radian), 15 * Mathf.Sin(radian), 0);

        return spawnpoint;
    }

    [Serializable]
    public class Wave
    {
        public int enemyCount; // 소환하는 적 수
        public float spawnDelay; // 소환 주기
        public GameObject enemy;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

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
    float playTime = 0;

    bool IsPause = false;
    public GameObject PauseImage;

    public TextMeshProUGUI timeText;
    int min = 0;
    int sec = 0;

    void Start()
    {
        Enemys = Resources.LoadAll<GameObject>("Enemys/");
        player = GameObject.Find("Player");

        NextWave();
    }

    void Update()
    {
        playTime += Time.deltaTime;
        if (endOfWaveTime >= playTime)
        {
            if (nextSpawntime <= playTime) // 생성 주기에 따라 적 스폰
            {
                nextSpawntime += currentWave.spawnDelay;
                SpawnEnemy(currentWave.enemy);
            }
        }
        else if (currentWaveNum < waves.Length)
        {
            NextWave();
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("VICTORY!");
        }

        sec = Mathf.FloorToInt(playTime);
        if(sec >= 60)
        {
            sec = 0;
            min += 1;
        }

        timeText.text = string.Format("{0:D2}:{1:D2}", min, sec);
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
        Vector2 radian = UnityEngine.Random.insideUnitCircle.normalized * 15;
        Vector3 spawnpoint;

        spawnpoint = new Vector3(radian.x, radian.y, 0);

        return spawnpoint;
    }

    [Serializable]
    public class Wave
    {
        public int enemyCount; // 소환하는 적 수
        public float spawnDelay; // 소환 주기
        public GameObject enemy;
    }

    public void Pause()
    {
        if (IsPause == false)
        {
            Time.timeScale = 0;
            PauseImage.SetActive(true);
            IsPause = true;
        }
        else
        {
            Time.timeScale = 1;
            PauseImage.SetActive(false);
            IsPause = false;
        }
    }


    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
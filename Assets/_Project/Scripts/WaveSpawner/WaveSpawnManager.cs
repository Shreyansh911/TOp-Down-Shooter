using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Wave
{
    public string name;
    public int noOfEnemies;
    public EnemyController[] enemiesPrefab;
    public float timeDelay;

    public EnemyController GetRandomEnemy()
    {
        return enemiesPrefab[Random.Range(0, enemiesPrefab.Length)];
    }
}

public class WaveSpawnManager : MonoBehaviour
{
    public static WaveSpawnManager Instance;

    public Transform[] SpawnPoints;

    public Wave[] waves;

    List<EnemyController> enemies;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        enemies = new List<EnemyController>();
        StartSpawn();
    }

    public void StartSpawn()
    {
        StartCoroutine(StartSpawningWaves());
    }

    public void RemoveEnenmy(EnemyController enemy)
    {
        enemies.Remove(enemy);
    }

    Transform GetRandomSpawnPos()
    {
        return SpawnPoints[Random.Range(0, SpawnPoints.Length)];
    }

    bool IsEnemyCointZero()
    {
        return enemies.Count == 0;
    }

    IEnumerator StartSpawningWaves()
    {
        foreach (var wave in waves)
        {
            Debug.Log($"Starting {wave.name}");
            GameObject.Find("Current Wave").GetComponent<TextMeshProUGUI>().text = wave.name;
            for (int i = 0; i < wave.noOfEnemies; i++)
            {
                Transform spawnPos = GetRandomSpawnPos();
                EnemyController enemy = Instantiate(wave.GetRandomEnemy(), spawnPos.position, Quaternion.identity);
                enemies.Add(enemy);
                yield return new WaitForSeconds(Random.Range(0f, 2f));
            }

            yield return new WaitUntil(IsEnemyCointZero);
            yield return new WaitForSeconds(wave.timeDelay);
        }

        Debug.Log("Game Complete");
    }
}

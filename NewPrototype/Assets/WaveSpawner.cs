using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBtwWaves = 5f;
    public float countdown = 2f;
    private float waitTime;

    public int waveNumber = 1; 

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(Spawn());
            countdown = timeBtwWaves; 
        }

        countdown -= Time.deltaTime;   
    }

    IEnumerator Spawn()
    {
        waitTime = Random.Range(5f, 10f);
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(waitTime);
        }

        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

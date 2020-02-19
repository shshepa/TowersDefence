using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance = null;

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    private float countDown = 5f;
    private int waveNumber = 1;

    private void Awake()
    {
        if(instance == null )
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        if(countDown <= 0)
        {
            SpawnWave();
            countDown = timeBetweenWaves;

        }
        countDown -= Time.deltaTime;
    }
    private void SpawnWave()
    {                                           //данную часть лучше реализовать через сопрограмму
        for (int i = 0; i < waveNumber; i++)    //  
        {
            SpawnEnemy();
        }
        waveNumber++;
    }
    private void SpawnEnemy() 
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

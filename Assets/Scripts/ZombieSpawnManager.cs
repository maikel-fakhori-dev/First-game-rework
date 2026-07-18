using System;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{

    public GameObject zombieNormal;
    public GameObject zombieFast;
    public GameObject zombieStrong;

    public int waveNumber = 1;

    private float spawnRange = 9;
    private int randomIndex;
    private int enemyCount;
    private GameObject[] zombies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zombies = new GameObject[]
        {
           zombieNormal,
           zombieFast,
           zombieStrong
        };
        
        SpawnEnemyWave(waveNumber);
    }
    private void SpawnEnemyWave(int enemiesToSpawn)
    {   for (int i = 0; i < enemiesToSpawn; i++)
        {
            randomIndex = UnityEngine.Random.Range(0, zombies.Length);
            Instantiate(zombies[randomIndex], GenerateSpawnPosition(), Quaternion.identity);
        }
    }
       


    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Zombie").Length;
        if (enemyCount == 0) { waveNumber++; SpawnEnemyWave(waveNumber); } ;
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = UnityEngine.Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = UnityEngine.Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3 (spawnPosX, 2, spawnPosZ);
        return randomPos;
    }
}

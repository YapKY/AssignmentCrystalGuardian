using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnemySpawner : MonoBehaviour
{

    [Header("Enemy Number")]
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private int baseEnemies = 5;
    [SerializeField] private float enemiesPersecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyFactor = 0.75f;

    //CrystalHealthBar hp;
    //float damage = 10f;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    public int enemiesAlive;
    private int enemyLeftSpawn;
    private bool isSpawning = false;

    [Header("Enemy Event")]
    public static UnityEvent onEnemyKilledOrDestroy = new UnityEvent(); 

    private void Awake()
    {
        onEnemyKilledOrDestroy.AddListener(enemyDestroyedOrKilled);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPersecond) && enemyLeftSpawn > 0)
        {
            SpawnEnemy();
            enemyLeftSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
            if (enemyLeftSpawn == 0)
            {
                enemiesAlive = enemiesAlive * enemys.Length;
            }
        }

        if(enemiesAlive == 0 && enemyLeftSpawn == 0)
        {
            EndEnemyWave();
        }
    }

    public void enemyDestroyedOrKilled()
    {
        enemiesAlive--;
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = enemys[0];
        GameObject enemyToSpawnRightUp = enemys[1];
        GameObject enemyToSpawnRightDown = enemys[2];
        GameObject enemyToSpawnLeftUp = enemys[3];
        GameObject enemyToSpawnLeftDown = enemys[4];
        GameObject enemyToSpawnLeftStraight = enemys[5];
        Instantiate(enemyToSpawn, EnemyManager.main.startingPoint.position, Quaternion.identity);
        Instantiate(enemyToSpawnRightUp, EnemyManager.main.startingPoint.position, Quaternion.identity);
        Instantiate(enemyToSpawnRightDown, EnemyManager.main.startingPoint.position, Quaternion.identity);
        Instantiate(enemyToSpawnLeftUp, EnemyManager.main.leftStartingPoint.position, Quaternion.identity);
        Instantiate(enemyToSpawnLeftDown, EnemyManager.main.leftStartingPoint.position, Quaternion.identity);
        Instantiate(enemyToSpawnLeftStraight, EnemyManager.main.leftStartingPoint.position, Quaternion.identity);
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        isSpawning = true;
        enemyLeftSpawn = EnemiesWave();
    }

    private void EndEnemyWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private int EnemiesWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyFactor));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo
    public Transform[] spawnPoints; // Pontos de respawn
    public float minSpawnInterval; // Intervalo m�nimo de spawn
    public float maxSpawnInterval; // Intervalo m�ximo de spawn
    public float enemySpeed; // Velocidade do inimigo

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Aguarda um tempo aleat�rio entre minSpawnInterval e maxSpawnInterval
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            // Escolhe aleatoriamente um ponto de respawn
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // Instancia o inimigo no ponto de respawn escolhido
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();

            // Define a velocidade do inimigo para ir em dire��o negativa ao eixo Z
            enemyRigidbody.velocity = Vector3.back * enemySpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectPoolSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints; // Lista de pontos de surgimento
    public GameObject[] enemyPrefabs; // Matriz de prefabs de inimigos
    public int enemySpeed;
    public float spawnInterval = 2f; // Intervalo de tempo entre a cria��o de inimigos

    // Intervalo de tempo entre a cria��o de inimigos
    public float minspawnInterval = 2f; 
    public float maxspawnInterval = 2f;

    private List<GameObject> activeEnemies; // Lista de inimigos ativos
    private Coroutine spawnCoroutine; // Refer�ncia para a coroutine de cria��o de inimigos

    private void Start()
    {
        
        activeEnemies = new List<GameObject>(); // Inicializa a lista de inimigos ativos
         // Inicia a coroutine de cria��o de inimigos
    }

    private void FixedUpdate()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }
    private void Update()
    {
        
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(spawnCoroutine); // Interrompe a coroutine de cria��o de inimigos
            spawnCoroutine = StartCoroutine(SpawnEnemies()); // Reinicia a coroutine de cria��o de inimigos
        }
        */
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); // Aguarda o intervalo de tempo definido

            int spawnIndex = Random.Range(0, spawnPoints.Count); // Seleciona aleatoriamente um �ndice de ponto de surgimento
            Transform spawnPoint = spawnPoints[spawnIndex]; // Obt�m o ponto de surgimento correspondente

            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; // Seleciona aleatoriamente um prefab de inimigo

            GameObject enemy = GetInactiveEnemy(); // Obt�m um inimigo inativo da lista de inimigos ativos
            if (enemy == null) // Se n�o houver inimigos inativos dispon�veis
            {
                enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity); // Instancia um novo inimigo
                activeEnemies.Add(enemy); // Adiciona o inimigo � lista de inimigos ativos
            }
            else // Se houver um inimigo inativo dispon�vel
            {
                enemy.transform.position = spawnPoint.position; // Reposiciona o inimigo no ponto de surgimento
                enemy.SetActive(true); // Ativa o inimigo
            }
            //Define a velocidade do inimigo para ir em dire��o negativa ao eixo Z
            Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
            enemyRigidbody.velocity = Vector3.back * enemySpeed;
        }
    }

    private GameObject GetInactiveEnemy()
    {
        foreach (GameObject enemy in activeEnemies) // Percorre a lista de inimigos ativos
        {
            if (!enemy.activeInHierarchy) // Verifica se o inimigo n�o est� ativo na hierarquia
                return enemy; // Retorna o inimigo inativo encontrado
        }
        return null;// Retorna null se n�o houver inimigos inativos dispon�veis
    }
}

using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    private int damageTaken = 0;
    public int maxHits = 2;
    
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    /*
    // Chamado quando o objeto colide com outro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se a colisão ocorreu com um objeto de dano
        if (collision.gameObject.CompareTag("LaserShoot"))
        {
            damageTaken++;

            // Verifica se o inimigo já levou o número máximo de hits
            if (damageTaken >= maxHits)
            {
                Die();
            }
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LaserShoot"))
        {
            damageTaken++;

            // Verifica se o inimigo já levou o número máximo de hits
            if (damageTaken >= maxHits)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        // Implemente o que acontece quando o inimigo morre aqui
        // Por exemplo, você pode tocar uma animação de morte, reproduzir um som, aumentar a pontuação do jogador, etc.
        Destroy(gameObject);
    }
}

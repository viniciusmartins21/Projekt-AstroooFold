using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playermovement : MonoBehaviour
{
    Rigidbody rb;
    public float forwardSpeed = 10f;     // Velocidade de movimento para frente
    public float sideSpeed = 5f;         // Velocidade de movimento lateral
    public float smoothness = 5f;        // Suavidade do movimento lateral

    private float targetPosition = 0f;   // Posição lateral alvo
    private float currentVelocity = 0f;  // Velocidade atual do movimento lateral


    //Controle UI
    public Image painelGameOver;

    private void Update()
    {
        // Movimento para frente constante
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Movimento lateral suave
        float moveHorizontal = Input.GetAxis("Horizontal");
        targetPosition += moveHorizontal * sideSpeed * Time.deltaTime;
        float newPosition = Mathf.SmoothDamp(transform.position.x, targetPosition, ref currentVelocity, smoothness);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            // Lógica para perder o jogo quando colidir com um asteroide
            Debug.Log("Game Over");
            painelGameOver.IsActive();
            Time.timeScale = 0;
            // Aqui você pode adicionar qualquer outra lógica que desejar, como reiniciar o jogo ou mostrar uma tela de Game Over.
        }
    }

}

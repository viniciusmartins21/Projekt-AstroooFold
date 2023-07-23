using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Playermovement : MonoBehaviour
{

    Rigidbody rb;
    public GameController gameController;
    public float speed = 0.01f;
    private Touch touch;
    public float velocityPlayer;
    private bool isMoving = false;  // Flag para verificar se o objeto est� se movendo
    
    //Controle UI
    public Image painelGameOver;
    public int assistSpeed;

    void Update()
    {
        MovementForward();

        MovementSide();
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Asteroid") == true)
        {
            gameController.GameOver();
        }
    }



    /* SE��O DE FUN�OES  */
    private void MovementForward()
    {
        // Verifica se o jogador est� tocando na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);  // Obt�m o primeiro toque na tela

            // Verifica se o toque come�ou
            if (touch.phase == TouchPhase.Began)
            {
                isMoving = true;  // O objeto come�a a se mover quando o toque come�a
            }
            // Verifica se o toque terminou
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isMoving = false;  // O objeto para de se mover quando o toque termina
            }
        }
        else
        {
            isMoving = false;  // O objeto para de se mover se n�o houver toque na tela
        }

        // Movimenta o objeto para frente se estiver se movendo
        if (isMoving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * assistSpeed);
        }
    }

    private void MovementSide()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            //verifica se o jogador esta indo para os lados
            if (touch.phase == TouchPhase.Moved)
            {

                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                    transform.position.y,
                    transform.position.z);
            }
        }
    }

}





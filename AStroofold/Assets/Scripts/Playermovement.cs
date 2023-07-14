using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playermovement : MonoBehaviour
{

    Rigidbody rb;
    public GameController gameController;
    public float speed = 0.01f;
    private Touch touch;     


    //Controle UI
    public Image painelGameOver;

    void Update()
    {
        /*
        // Movimento lateral suave
        float moveHorizontal = Input.GetAxis("Horizontal");
        targetPosition += moveHorizontal * sideSpeed * Time.fixedDeltaTime;
        float newPosition = Mathf.SmoothDamp(transform.position.x, targetPosition, ref currentVelocity, smoothness);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        */



        /* Teste movimentação */
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                    transform.position.y,
                    transform.position.z);

            }
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Asteroid") == true)
        {
            gameController.GameOver();
        }
    }

}

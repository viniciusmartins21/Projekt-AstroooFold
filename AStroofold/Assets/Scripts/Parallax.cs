using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax: MonoBehaviour
{
    public Transform[] backgrounds; // Array de objetos de fundo (galáxias)
    public float[] parallaxScales; // Fatores de escala para o efeito de paralaxe
    public float parallaxSpeed; // Velocidade do efeito de paralaxe
    public float smoothing; // Suavização do movimento dos objetos de fundo

    private Transform cameraTransform; // Transform da câmera principal
    private Vector3 previousCameraPosition; // Posição anterior da câmera

    private void Start()
    {
        cameraTransform = Camera.main.transform; // Obtém a transform da câmera principal
        previousCameraPosition = cameraTransform.position; // Define a posição anterior da câmera
    }

    private void Update()
    {
        // Calcula o deslocamento de paralaxe com base na posição anterior e atual da câmera
        float parallax = (previousCameraPosition.x - cameraTransform.position.x) * parallaxSpeed;

        // Para cada objeto de fundo, aplica o efeito de paralaxe de acordo com o fator de escala
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Calcula o deslocamento alvo do objeto de fundo
            float backgroundTargetPosX = backgrounds[i].position.x + parallax * parallaxScales[i];
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Suaviza o movimento do objeto de fundo usando a função Lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Atualiza a posição anterior da câmera
        previousCameraPosition = cameraTransform.position;
    }
}



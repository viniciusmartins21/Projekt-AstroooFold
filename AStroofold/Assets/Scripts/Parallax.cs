using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax: MonoBehaviour
{
    public Transform[] backgrounds; // Array de objetos de fundo (gal�xias)
    public float[] parallaxScales; // Fatores de escala para o efeito de paralaxe
    public float parallaxSpeed; // Velocidade do efeito de paralaxe
    public float smoothing; // Suaviza��o do movimento dos objetos de fundo

    private Transform cameraTransform; // Transform da c�mera principal
    private Vector3 previousCameraPosition; // Posi��o anterior da c�mera

    private void Start()
    {
        cameraTransform = Camera.main.transform; // Obt�m a transform da c�mera principal
        previousCameraPosition = cameraTransform.position; // Define a posi��o anterior da c�mera
    }

    private void Update()
    {
        // Calcula o deslocamento de paralaxe com base na posi��o anterior e atual da c�mera
        float parallax = (previousCameraPosition.x - cameraTransform.position.x) * parallaxSpeed;

        // Para cada objeto de fundo, aplica o efeito de paralaxe de acordo com o fator de escala
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Calcula o deslocamento alvo do objeto de fundo
            float backgroundTargetPosX = backgrounds[i].position.x + parallax * parallaxScales[i];
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Suaviza o movimento do objeto de fundo usando a fun��o Lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Atualiza a posi��o anterior da c�mera
        previousCameraPosition = cameraTransform.position;
    }
}



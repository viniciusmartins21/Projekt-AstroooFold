using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Parallax : MonoBehaviour
{

    public float parallaxSpeed = 0.5f; // Velocidade de paralaxe para controlar a velocidade de deslocamento das estrelas
    public Transform[] backgrounds; // Array de transformações das camadas de estrelas
    private float[] parallaxScales; // Array das escalas de paralaxe para cada camada
    private Transform cameraTransform; // Transformação da câmera principal
    private Vector3 previousCameraPosition; // Posição anterior da câmera

    private void Start()
    {
        cameraTransform = Camera.main.transform; // Obtém a transformação da câmera principal
        previousCameraPosition = cameraTransform.position; // Inicializa a posição anterior da câmera

        parallaxScales = new float[backgrounds.Length]; // Inicializa o array das escalas de paralaxe
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1; // Define a escala de paralaxe para cada camada de acordo com a posição z
        }
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCameraPosition.x - cameraTransform.position.x) * parallaxScales[i]; // Calcula o deslocamento de paralaxe baseado na diferença da posição anterior e atual da câmera
            float backgroundTargetPositionX = backgrounds[i].position.x + parallax; // Calcula a nova posição X da camada de estrelas
            Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z); // Cria o vetor com a nova posição
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, parallaxSpeed * Time.deltaTime); // Move a camada de estrelas em direção à nova posição usando Lerp para suavizar o movimento
        }

        previousCameraPosition = cameraTransform.position; // Atualiza a posição anterior da câmera para a próxima iteração
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
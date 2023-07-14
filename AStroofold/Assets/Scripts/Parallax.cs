using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Parallax : MonoBehaviour
{

    public float parallaxSpeed = 0.5f; // Velocidade de paralaxe para controlar a velocidade de deslocamento das estrelas
    public Transform[] backgrounds; // Array de transforma��es das camadas de estrelas
    private float[] parallaxScales; // Array das escalas de paralaxe para cada camada
    private Transform cameraTransform; // Transforma��o da c�mera principal
    private Vector3 previousCameraPosition; // Posi��o anterior da c�mera

    private void Start()
    {
        cameraTransform = Camera.main.transform; // Obt�m a transforma��o da c�mera principal
        previousCameraPosition = cameraTransform.position; // Inicializa a posi��o anterior da c�mera

        parallaxScales = new float[backgrounds.Length]; // Inicializa o array das escalas de paralaxe
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1; // Define a escala de paralaxe para cada camada de acordo com a posi��o z
        }
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCameraPosition.x - cameraTransform.position.x) * parallaxScales[i]; // Calcula o deslocamento de paralaxe baseado na diferen�a da posi��o anterior e atual da c�mera
            float backgroundTargetPositionX = backgrounds[i].position.x + parallax; // Calcula a nova posi��o X da camada de estrelas
            Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z); // Cria o vetor com a nova posi��o
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, parallaxSpeed * Time.deltaTime); // Move a camada de estrelas em dire��o � nova posi��o usando Lerp para suavizar o movimento
        }

        previousCameraPosition = cameraTransform.position; // Atualiza a posi��o anterior da c�mera para a pr�xima itera��o
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
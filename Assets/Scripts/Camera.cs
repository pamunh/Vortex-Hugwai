using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;       // Referência ao Transform do jogador
    public Vector3 offset;         // Deslocamento da câmera em relação ao jogador
    public float smoothSpeed = 0.125f; // Velocidade de suavização da movimentação da câmera

    void FixedUpdate()
    {
        // Verifica se o jogador foi atribuído
        if (Player != null)
        {
            // Calcula a nova posição da câmera
            Vector3 desiredPosition = Player.position + offset;
            // Interpola suavemente entre a posição atual da câmera e a posição desejada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Atualiza a posição da câmera
            transform.position = smoothedPosition;
        }
    }
}

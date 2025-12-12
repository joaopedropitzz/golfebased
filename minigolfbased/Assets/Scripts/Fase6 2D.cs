using UnityEngine;

public class Fase62D : MonoBehaviour
{
    [Header("Configurações da Câmera 2D")]
    public float altura = 25f;
    public float tamanhoVisao = 25f;
    public float suavizacaoRotacao = 5f;
    public float inclinacaoExtra = 0f;
    public bool seguirPlayer = false;
    public Transform player;

    [Header("Limites da Fase (Opcional)")]
    public bool limitarArea = false;
    public Vector2 limiteMin;
    public Vector2 limiteMax;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        if (cam == null)
        {
            Debug.LogError("Este script deve estar em uma CÂMERA!");
            return;
        }

        cam.orthographic = true;
        cam.orthographicSize = tamanhoVisao;

        // Rotação corrigida: 90° no X + 180° no Y
        transform.rotation = Quaternion.Euler(90f + inclinacaoExtra, 180f, 0f);
    }

    void LateUpdate()
    {
        Vector3 novaPosicao = transform.position;

        if (seguirPlayer && player != null)
        {
            novaPosicao = new Vector3(
                player.position.x,
                altura,
                player.position.z
            );
        }
        else
        {
            novaPosicao.y = altura;
        }

        if (limitarArea)
        {
            novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteMin.x, limiteMax.x);
            novaPosicao.z = Mathf.Clamp(novaPosicao.z, limiteMin.y, limiteMax.y);
        }

        transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.deltaTime * 10f);

        // Rotação suave corrigida
        Quaternion alvoRotacao = Quaternion.Euler(90f + inclinacaoExtra, 180f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, alvoRotacao, Time.deltaTime * suavizacaoRotacao);
    }
}

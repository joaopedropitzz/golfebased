using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase5Cube : MonoBehaviour
{
    [Header("Movimento Vertical")]
    public float altura = 3f;
    public float velocidade = 2f;

    private Vector3 posInicial;

    void Start()
    {
        posInicial = transform.position;
    }

    void Update()
    {
        float novaY = posInicial.y + Mathf.PingPong(Time.time * velocidade, altura);
        transform.position = new Vector3(posInicial.x, novaY, posInicial.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 🔥 Salvar tacadas antes de reiniciar a fase
            if (GameManager.gm != null)
                GameManager.gm.SalvarTacadasTemporarias();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

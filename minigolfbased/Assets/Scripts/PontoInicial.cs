using UnityEngine;
using UnityEngine.SceneManagement;

public class PontoInicial : MonoBehaviour
{
    private bool podeReiniciar = true;

    private void Start()
    {
        // Espera 1 segundo antes de permitir reinício
        Invoke(nameof(AtivarReinicio), 1f);
    }

    private void AtivarReinicio()
    {
        podeReiniciar = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (podeReiniciar && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

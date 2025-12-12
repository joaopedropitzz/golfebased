using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ProximaFase : MonoBehaviour
{
    [SerializeField] private string nomeDaCena;
    [SerializeField] private float tempoEspera = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManager.gm != null)
        {
            GameManager.gm.FinalizarFase();
        }

        StartCoroutine(TrocarDeFase());
    }

    private IEnumerator TrocarDeFase()
    {
        yield return new WaitForSeconds(tempoEspera);

        string cenaAtual = SceneManager.GetActiveScene().name;

        if (string.IsNullOrEmpty(nomeDaCena))
        {
            int indiceAtual = SceneManager.GetActiveScene().buildIndex;
            int proximaCena = indiceAtual + 1;

            if (proximaCena < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(proximaCena);
            }
        }
        else
        {
            if (nomeDaCena != cenaAtual)
            {
                SceneManager.LoadScene(nomeDaCena);
            }
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [Header("UI")]
    public TMP_Text textTacadas;
    public TMP_Text textPar;
    public TMP_Text textRecorde;
    public TMP_Text textResultadoFinal;

    [Header("Pontuação")]
    public int tacadas;
    public int par;
    private int recorde;

    void Awake()
    {
        if (gm == null)
            gm = this;
    }

    void Start()
    {
        // 🔥 Carrega tacadas salvas temporariamente
        CarregarTacadasTemporarias();

        // Define par por fase
        string cenaAtual = SceneManager.GetActiveScene().name;

        if (cenaAtual == "Fase1") par = 3;
        else if (cenaAtual == "Fase2") par = 4;
        else par = 5;

        // Carrega recorde salvo
        recorde = PlayerPrefs.GetInt("Recorde_" + cenaAtual, int.MaxValue);

        AtualizarUI();

        if (textResultadoFinal != null)
            textResultadoFinal.text = "";
    }

    // ===========================================================
    // SISTEMA DE TACADAS
    // ===========================================================

    public void tacada()
    {
        tacadas++;
        AtualizarUI();
    }

    // 🔥 SALVA TACADAS AO MORRER / REINICIAR
    public void SalvarTacadasTemporarias()
    {
        PlayerPrefs.SetInt("TacadasTemp", tacadas);
        PlayerPrefs.Save();
    }

    // 🔥 CARREGA TACADAS QUANDO A FASE REINICIA
    public void CarregarTacadasTemporarias()
    {
        tacadas = PlayerPrefs.GetInt("TacadasTemp", 0);
    }

    // 🔥 LIMPA TACADAS TEMPORÁRIAS QUANDO ZERA FASE
    public void LimparTacadasTemporarias()
    {
        PlayerPrefs.DeleteKey("TacadasTemp");
    }

    // ===========================================================
    // UI
    // ===========================================================

    private void AtualizarUI()
    {
        if (textTacadas != null) textTacadas.text = "Tacadas: " + tacadas;
        if (textPar != null) textPar.text = "Par: " + par;

        if (textRecorde != null)
        {
            textRecorde.text = (recorde == int.MaxValue)
                ? "Recorde: -"
                : "Recorde: " + recorde;
        }
    }

    // ===========================================================
    // FINALIZAÇÃO DE FASE
    // ===========================================================

    public void FinalizarFase()
    {
        int diferenca = tacadas - par;
        string resultado = CalcularResultadoGolf(diferenca);

        if (textResultadoFinal != null)
        {
            textResultadoFinal.text =
                "Recorde Final!\n" +
                "Resultado: " + resultado + "\n" +
                "Tacadas: " + tacadas + " | Par: " + par;
        }

        // Atualiza recorde
        string cenaAtual = SceneManager.GetActiveScene().name;

        if (tacadas < recorde)
        {
            recorde = tacadas;
            PlayerPrefs.SetInt("Recorde_" + cenaAtual, recorde);
            PlayerPrefs.Save();
        }

        // 🔥 FINALIZOU A FASE → limpar tacadas temporárias
        LimparTacadasTemporarias();

        AtualizarUI();
    }

    private string CalcularResultadoGolf(int diferenca)
    {
        if (diferenca <= -3) return "Albatross";
        if (diferenca == -2) return "Eagle";
        if (diferenca == -1) return "Birdie";
        if (diferenca == 0) return "Par";
        if (diferenca == 1) return "Bogey";
        if (diferenca == 2) return "Double Bogey";
        return "Over Par";
    }
}

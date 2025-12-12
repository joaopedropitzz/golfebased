using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string nomeDaFase = "Fase1";
    private Canvas canvas;
    private Font fonte;

    void Start()
    {
        CriarUI();
    }

    void CriarUI()
    {
        // Carregar fonte correta
        fonte = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");

        // Criar Canvas
        GameObject canvasObj = new GameObject("MenuCanvas");
        canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        // Criar fundo cinza
        GameObject fundo = new GameObject("Fundo");
        fundo.transform.SetParent(canvasObj.transform);
        Image imgFundo = fundo.AddComponent<Image>();
        imgFundo.color = new Color(0.2f, 0.2f, 0.2f, 1f); // cinza escuro

        RectTransform rtFundo = fundo.GetComponent<RectTransform>();
        rtFundo.anchorMin = Vector2.zero;
        rtFundo.anchorMax = Vector2.one;
        rtFundo.offsetMin = Vector2.zero;
        rtFundo.offsetMax = Vector2.zero;

        // Criar texto de título
        GameObject textoObj = new GameObject("Titulo");
        textoObj.transform.SetParent(canvasObj.transform);
        Text txt = textoObj.AddComponent<Text>();
        txt.text = "Meu Jogo";
        txt.font = fonte;
        txt.fontSize = 70;
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = Color.white;

        RectTransform rtTexto = textoObj.GetComponent<RectTransform>();
        rtTexto.sizeDelta = new Vector2(600, 200);
        rtTexto.anchoredPosition = new Vector2(0, 200);

        // Criar botão
        GameObject botaoObj = new GameObject("BotaoIniciar");
        botaoObj.transform.SetParent(canvasObj.transform);

        Button btn = botaoObj.AddComponent<Button>();
        Image imgBtn = botaoObj.AddComponent<Image>();
        imgBtn.color = new Color(0.9f, 0.9f, 0.9f); // cinza claro

        RectTransform rtBtn = botaoObj.GetComponent<RectTransform>();
        rtBtn.sizeDelta = new Vector2(300, 120);
        rtBtn.anchoredPosition = new Vector2(0, -50);

        // Criar texto dentro do botão
        GameObject txtBtnObj = new GameObject("TextoBotao");
        txtBtnObj.transform.SetParent(botaoObj.transform);
        Text txtBtn = txtBtnObj.AddComponent<Text>();
        txtBtn.text = "INICIAR";
        txtBtn.font = fonte;
        txtBtn.fontSize = 48;
        txtBtn.color = Color.black;
        txtBtn.alignment = TextAnchor.MiddleCenter;

        RectTransform rtTxtBtn = txtBtnObj.GetComponent<RectTransform>();
        rtTxtBtn.anchorMin = Vector2.zero;
        rtTxtBtn.anchorMax = Vector2.one;
        rtTxtBtn.offsetMin = Vector2.zero;
        rtTxtBtn.offsetMax = Vector2.zero;

        // Ação do botão
        btn.onClick.AddListener(IniciarFase);

        Debug.Log("Menu criado com sucesso!");
    }

    void IniciarFase()
    {
        SceneManager.LoadScene(nomeDaFase);
    }
}

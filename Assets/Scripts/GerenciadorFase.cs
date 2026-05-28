using UnityEngine;
using TMPro;

public class GerenciadorFase : MonoBehaviour
{
    public static int quantidadeMoedas = 0;
    public TextMeshProUGUI MoedasColetadas;

    // float tempoFase;

    void Start()
    {
        AtualizarMoedas();
    }

    public void AdicionarMoedas()
    {
          quantidadeMoedas++;
          AtualizarMoedas();
    }
    public void AtualizarMoedas()
    {
        MoedasColetadas.text = "X " + quantidadeMoedas;
    }
}

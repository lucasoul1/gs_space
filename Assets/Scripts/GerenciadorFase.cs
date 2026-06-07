using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GerenciadorFase : MonoBehaviour
{
    public bool FaseDeIda = true;
    public string fase;
    public static int quantidadeMoedas = 0;
    public TextMeshProUGUI MoedasColetadas;

    // float tempoFase;

    void Start()
    {
        AtualizarMoedas();
        if(SceneManager.GetActiveScene().name == "LuaIda")
        {
            FaseDeIda = true;
            print(FaseDeIda);
        }
    }

        public void carregarProximaFase()
    {
        SceneManager.LoadScene(fase);
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

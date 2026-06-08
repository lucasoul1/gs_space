using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GerenciadorFase : MonoBehaviour
{
    public bool FaseDeIda = false;
    public string fase;
    public static int quantidadeMoedas = 0;
    public TextMeshProUGUI MoedasColetadas;

    // float tempoFase;

    void Start()
    {

        AtualizarMoedas();
        if(SceneManager.GetActiveScene().name == "LuaIda" ||SceneManager.GetActiveScene().name == "EuropaIda" )
        {
            FaseDeIda = true;
            print(FaseDeIda);
        }
        else
        {
            FaseDeIda = false;
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

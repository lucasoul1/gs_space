using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Quando o jogador chegar ao final da fase, ela vai para a próxima
        if (collision.CompareTag("Astronauta"))
        {
            // Adicionar Moedas pegas ao Inventário
            Inventario.moedasInventario += GerenciadorFase.quantidadeMoedas;

            carregarProximaFase();
        }
    }

    // Função para carregar a Próxima Fase
    public void carregarProximaFase()
    {
        int cenaAtual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cenaAtual + 1);
    }
}

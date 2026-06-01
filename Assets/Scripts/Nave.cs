using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
    private float velocidade;
    float posicaoInicialX;
    float posicaoInicialY;

    void Start()
    {
        // Propriedas Iniciais
        velocidade = 0.3f;
        posicaoInicialX = transform.position.x;
        posicaoInicialY = transform.position.y;
    }

    void Update()
    {
        movimentacaoVertical();
    }

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

    void movimentacaoVertical()
    {
        float limitePositivo = posicaoInicialY + 0.2f;
        float limiteNegativo = posicaoInicialY - 0.2f;

        transform.Translate(0f, velocidade * Time.deltaTime, 0f);

        if (transform.position.y >= limitePositivo || transform.position.y <= limiteNegativo)
        {
            velocidade *= -1;
        }
    }
}

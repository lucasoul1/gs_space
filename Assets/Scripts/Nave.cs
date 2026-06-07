using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
    private float velocidade;
    float posicaoInicialX;
    float posicaoInicialY;

    public GerenciadorFase gerenciador;

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
        // Quando o jogador chegar ao final da fase, ela vai para a pr�xima
        if (collision.CompareTag("Astronauta") && gerenciador.FaseDeIda == false)
        {
            // Adicionar Moedas pegas ao Invent�rio
            Inventario.moedasInventario += GerenciadorFase.quantidadeMoedas;

            gerenciador.carregarProximaFase();
        }
    }

    // Fun��o para carregar a Pr�xima Fase


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

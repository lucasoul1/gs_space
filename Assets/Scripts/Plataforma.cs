using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private float velocidade;

    float posicaoInicialX;
    float posicaoInicialY;

    void Start()
    {
        // Propriedas Iniciais
        velocidade = Random.Range(-1f, 1f);

        posicaoInicialX = transform.position.x;
        posicaoInicialY = transform.position.y;
    }

    void Update()
    {
        // Movimentar Plataformas
        if (CompareTag("PlataformaHorizontal"))
        {
            movimentacaoHorizontal();
        }
        else if (CompareTag("PlataformaVertical"))
        {
            movimentacaoVertical();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sumir Plataformas
        if (gameObject.CompareTag("PlataformaSome"))
        {
            if (collision.gameObject.CompareTag("Astronauta"))
            {
                Destroy(gameObject, 2f);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Verificando Colisão de entrada com o Astronauta
        if (collision.gameObject.CompareTag("Astronauta"))
        {
            Astronauta.estaNoChao = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verificando Colisão de saída com o Astronauta
        if (collision.gameObject.CompareTag("Astronauta"))
        {
            Astronauta.estaNoChao = false;
        }
    }

    // Funcao de Movimentação das Plataformas
    void movimentacaoHorizontal()
    {
        float limitePositivo = posicaoInicialX + 1f;
        float limiteNegativo = posicaoInicialX - 1f;

        transform.Translate(velocidade * Time.deltaTime, 0f, 0f);

        if (transform.position.x >= limitePositivo || transform.position.x <= limiteNegativo)
        {
            velocidade *= -1;
        }
    }

    void movimentacaoVertical()
    {
        float limitePositivo = posicaoInicialY + 1f;
        float limiteNegativo = posicaoInicialY - 1f;

        transform.Translate(0f, velocidade * Time.deltaTime, 0f);

        if (transform.position.y >= limitePositivo || transform.position.y <= limiteNegativo)
        {
            velocidade *= -1;
        }
    }
}
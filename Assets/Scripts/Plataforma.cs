using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private float velocidade;

    float posicaoInicialX;
    float posicaoInicialY;

    void Start()
    {
        // Propriedades Iniciais
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

        // Fazer o jogador acompanhar a plataforma
        if (collision.gameObject.CompareTag("Astronauta"))
        {
            foreach (ContactPoint2D contato in collision.contacts)
            {
                if (contato.normal.y < -0.5f)
                {
                    collision.transform.SetParent(transform);
                    break;
                }
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
            collision.transform.SetParent(null);
        }
    }

    // Função de Movimentação Horizontal
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

    // Função de Movimentação Vertical
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
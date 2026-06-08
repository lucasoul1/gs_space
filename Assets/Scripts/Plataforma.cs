using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField] private float posicaoFinal = 1f;

    private float velocidade;
    private float posicaoInicialX;
    private float posicaoInicialY;

    void Start()
    {
        // Propriedades Iniciais
        velocidade = 1f;

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
        if (CompareTag("PlataformaSome"))
        {
            if (collision.gameObject.CompareTag("Astronauta"))
            {
                Destroy(gameObject, 2f);
            }
        }

        // Fazer o jogador acompanhar APENAS plataformas móveis
        if (collision.gameObject.CompareTag("Astronauta") &&
            (CompareTag("PlataformaHorizontal") ||
             CompareTag("PlataformaVertical")))
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

            // Remove o parent apenas se estiver usando plataforma móvel
            if (collision.transform.parent == transform)
            {
                collision.transform.SetParent(null);
            }
        }
    }

    // Função de Movimentação Horizontal
    void movimentacaoHorizontal()
    {
        float limitePositivo = posicaoInicialX + posicaoFinal;
        float limiteNegativo = posicaoInicialX - posicaoFinal;

        transform.Translate(velocidade * Time.deltaTime, 0f, 0f);

        if (transform.position.x >= limitePositivo ||
            transform.position.x <= limiteNegativo)
        {
            velocidade *= -1;
        }
    }

    // Função de Movimentação Vertical
    void movimentacaoVertical()
    {
        float limitePositivo = posicaoInicialY + posicaoFinal;
        float limiteNegativo = posicaoInicialY - posicaoFinal;

        transform.Translate(0f, velocidade * Time.deltaTime, 0f);

        if (transform.position.y >= limitePositivo ||
            transform.position.y <= limiteNegativo)
        {
            velocidade *= -1;
        }
    }
}
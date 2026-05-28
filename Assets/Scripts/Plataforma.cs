using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField] private float velocidade = 1f;
    
    void Update()
    {
        // Movimentar Plataformas
        if (CompareTag("PlataformaHorizontal"))
        {
            movimentacaoHorizontal();
        }
        else if (CompareTag("PlataformaHorizontal") && gameObject.name == "PlataformaSome")
        {
            movimentacaoHorizontal();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sumir Plataformas
        if(gameObject.name == "PlataformaSome")
        {
            if (collision.gameObject.CompareTag("Astronauta"))
            {
                Destroy(gameObject, 1.5f);
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
        transform.Translate(velocidade * Time.deltaTime, 0f, 0f);

        if (transform.position.x >= 1f || transform.position.x <= -1f)
        {
            velocidade *= -1;
        }
    }

    void movimentacaoVertical()
    {
        transform.Translate(0f, velocidade * Time.deltaTime, 0f);
    }
}

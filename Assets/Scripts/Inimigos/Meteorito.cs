using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Meteorito : MonoBehaviour
{
    [SerializeField] private float velocidade;
    private float velocidadeRotacao;

    private void Start()
    {
        velocidade = Random.Range(-2, 3f);
        velocidadeRotacao = Random.Range(1f, 41f);
    }

    void Update()
    {
        movimentacaoHorizontal();
        rotacaoMeteorito();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Colisoes com o espaço ou entre os Meteoritos
        if (collision.gameObject.CompareTag("Espaco"))
        {
            // Inverte a direção do meteorito
            velocidade *= -1;
        }
        else if (collision.gameObject.CompareTag("Inimigo"))
        {
            velocidade *= -1;
        }

    }

    void movimentacaoHorizontal()
    {
        transform.Translate(velocidade * Time.deltaTime, 0f, 0f);
    }

    void rotacaoMeteorito()
    {
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
    }
}

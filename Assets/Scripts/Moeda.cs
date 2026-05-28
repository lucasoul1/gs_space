using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField] private float velocidadeRotacao = 130f;
    [SerializeField] private GerenciadorFase Moedas;

    void Update()
    {
        rotacaoMoeda();
    }

    void rotacaoMoeda()
    {
        transform.Rotate(0f, velocidadeRotacao * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Astronauta"))
        {
            Moedas.AdicionarMoedas();
            Destroy(gameObject);
        }
    }
}

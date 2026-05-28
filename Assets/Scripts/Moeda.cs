using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField] private float velocidadeRotacao = 130f;

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
            GerenciadorFase.quantidadeMoedas++;
            print(GerenciadorFase.quantidadeMoedas);
            Destroy(gameObject);
        }
    }
}

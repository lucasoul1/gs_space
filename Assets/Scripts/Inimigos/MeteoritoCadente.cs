using UnityEngine;

public class MeteoritoCadente : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private float velocidadeRotacao = 90f;
    [SerializeField] private float LimiteY = -5;

    private void Start()
    {
        velocidade = -2f;
    }

    void Update()
    {
        movimentoQueda();
        rotacaoMeteorito();
        despawnar();
    }

    void despawnar()
    {
        if (transform.position.y <= LimiteY)
        {
            Destroy(gameObject);
        }
    }

    void movimentoQueda()
    {
        transform.Translate(0f, velocidade * Time.deltaTime, 0f, Space.World);
    }

    void rotacaoMeteorito()
    {
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
    }
}
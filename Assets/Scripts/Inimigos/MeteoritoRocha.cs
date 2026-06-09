using UnityEngine;

public class MeteoritoRocha : MonoBehaviour
{
    [SerializeField] private float limiteSuperior;
    [SerializeField] private float limiteInferior;
    private float velocidade;
    private float velocidadeRotacao = 90f;


    void Start()
    {
        limiteSuperior = 3.5f;
        limiteInferior = -4f;
        velocidade = 1f;
    }

    void Update()
    {
        if (transform.position.y <= limiteInferior)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y >= limiteSuperior) 
        {
            velocidade = -3f;
        }
        movimentoVertical();
        movimentoRotacao();
    }

    void movimentoVertical()
    {
        transform.Translate(0f, velocidade * Time.deltaTime, 0f, Space.World);
    }

    void movimentoRotacao()
    {
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
    }
}
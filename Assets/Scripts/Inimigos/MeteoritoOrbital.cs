using UnityEngine;

public class MeteoritoOrbital : MonoBehaviour
{

    [SerializeField] private float velocidade = -2.5f;
    [SerializeField] private float velocidadeRotacao = 90f;

    void Update()
    {
        movimentoQueda();
        rotacaoMeteorito();
    }

    void movimentoQueda()
    {
        transform.Translate(0f, velocidade * Time.deltaTime, 0f);
    }

    void rotacaoMeteorito()
    {
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
    }
}
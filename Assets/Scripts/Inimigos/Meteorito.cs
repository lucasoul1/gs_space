using UnityEngine;

public class Meteorito : MonoBehaviour
{
    [SerializeField] private float velocidade = 2f;
    [SerializeField] private float velocidadeRotacao;
    [SerializeField] private bool destruirAoTocarParede = false;


    private void Start()
    {
        velocidadeRotacao = Random.Range(20f, 80f);
    }

    void Update()
    {
        MovimentacaoHorizontal();
        RotacaoMeteorito();
    }
    public void ConfigurarDestruicaoNaParede(bool deveDestruir)
{
    destruirAoTocarParede = deveDestruir;
}

    public void ConfigurarVelocidade(float novaVelocidade)
    {
        velocidade = novaVelocidade;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Espaco"))
            {
            if(destruirAoTocarParede)
            {
                Destroy(gameObject);

            }
            else
            {
                velocidade *= -1;
            }
            }

    }

    void MovimentacaoHorizontal()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime, Space.World);
    }

    void RotacaoMeteorito()
    {
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
    }
}
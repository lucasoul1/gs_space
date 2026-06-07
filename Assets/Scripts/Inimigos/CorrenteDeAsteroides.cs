using System.Collections;
using UnityEngine;


public class CorrenteDeAsteroides : MonoBehaviour
{
    //Prefab
    [SerializeField] private GameObject meteoritoPrefab;

    [SerializeField] private float intervaloSpawn = 0.25f;
    [SerializeField] private float tempoAtivo = 3f;
    [SerializeField] private float tempoSemSpawn = 1.2f;

    //Movimento dos meteoritos
    [SerializeField] private float velocidadeMeteorito = 4f;

    //Direção
    [SerializeField] private bool moverParaDireita = true;

    private BoxCollider2D areaSpawn;

        private void Awake()
    {
        areaSpawn = GetComponent<BoxCollider2D>();
    }

private void Start()
    {
        StartCoroutine(Corrente());
    }

private IEnumerator Corrente()
    {
        while (true)
        {
            float tempoAtual = 0f;

            // Período em que a parede está criando meteoritos
            while (tempoAtual < tempoAtivo)
            {
                SpawnarMeteorito();

                yield return new WaitForSeconds(intervaloSpawn);

                tempoAtual += intervaloSpawn;
            }

            // Período sem criar meteoritos, gerando a passagem
            yield return new WaitForSeconds(tempoSemSpawn);
        }
        
        
    }
    private void SpawnarMeteorito()
    {
        float x = transform.position.x;

        float yMin = areaSpawn.bounds.min.y;
        float yMax = areaSpawn.bounds.max.y;

        float yAleatorio = Random.Range(yMin, yMax);

        Vector3 posicaoSpawn = new Vector3(x, yAleatorio, transform.position.z);

        GameObject novoMeteorito = Instantiate(
            meteoritoPrefab,
            posicaoSpawn,
            Quaternion.identity
        );

        Meteorito meteorito = novoMeteorito.GetComponent<Meteorito>();

        if (meteorito != null)
        {
              float direcao = moverParaDireita ? 1f : -1f;

            meteorito.ConfigurarVelocidade(velocidadeMeteorito * direcao);

            meteorito.ConfigurarDestruicaoNaParede(true);  
            
        }

    }
}
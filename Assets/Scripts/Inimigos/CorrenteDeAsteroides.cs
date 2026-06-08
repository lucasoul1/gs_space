using System.Collections;
using UnityEngine;

public class CorrenteDeAsteroides : MonoBehaviour
{
    // Prefab
    [SerializeField] private GameObject meteoritoPrefab;

    // Spawn
    [SerializeField] private float intervaloSpawn = 0.25f;
    [SerializeField] private float tempoAtivo = 3f;

    // Tempo aleatório sem spawn
    [SerializeField] private float tempoSemSpawnMin = 1f;
    [SerializeField] private float tempoSemSpawnMax = 3f;

    // Movimento dos meteoritos
    [SerializeField] private float velocidadeMeteorito = 4f;

    // Direção
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

            // Período em que a corrente gera meteoritos
            while (tempoAtual < tempoAtivo)
            {
                SpawnarMeteorito();

                yield return new WaitForSeconds(intervaloSpawn);

                tempoAtual += intervaloSpawn;
            }

            // Sorteia um tempo aleatório sem spawn
            float tempoSemSpawnAleatorio =
                Random.Range(tempoSemSpawnMin, tempoSemSpawnMax);

            yield return new WaitForSeconds(tempoSemSpawnAleatorio);
        }
    }

    private void SpawnarMeteorito()
    {
        float x = transform.position.x;

        float yMin = areaSpawn.bounds.min.y;
        float yMax = areaSpawn.bounds.max.y;

        float yAleatorio = Random.Range(yMin, yMax);

        Vector3 posicaoSpawn = new Vector3(
            x,
            yAleatorio,
            transform.position.z
        );

        GameObject novoMeteorito = Instantiate(
            meteoritoPrefab,
            posicaoSpawn,
            Quaternion.identity
        );

        Meteorito meteorito = novoMeteorito.GetComponent<Meteorito>();

        if (meteorito != null)
        {
            float direcao = moverParaDireita ? 1f : -1f;

            meteorito.ConfigurarVelocidade(
                velocidadeMeteorito * direcao
            );

            meteorito.ConfigurarDestruicaoNaParede(true);
        }
    }
}
using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField] private float velocidadeRotacao = 130f;
    private AudioSource audioSource;
    private GerenciadorFase Moedas;

    void Start()
    {
        Moedas = FindFirstObjectByType<GerenciadorFase>();
        audioSource = GetComponent<AudioSource>();
    }

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
        if (collision.CompareTag("Astronauta"))
        {
            // Adiona as Moedas na HUD
            Moedas.AdicionarMoedas();
            // Toca o som
            audioSource.Play();
            // Tira a Moeda da tela
            Destroy(gameObject, 0.45f);
        }
    }
}
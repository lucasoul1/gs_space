using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    // Propriedades
    private Game_over gameOver;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOver = FindFirstObjectByType<Game_over>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Tomando dano volta a fase
        if (collision.gameObject.CompareTag("Astronauta"))
        {
            audioSource.Play();
            gameOver.GameOver = true;
            GerenciadorFase.quantidadeMoedas = 0;
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    private Game_over gameOver;

    void Start()
    {
        gameOver = FindFirstObjectByType<Game_over>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Tomando dano volta a fase
        if (collision.gameObject.CompareTag("Astronauta"))
        {
            gameOver.GameOver = true;
            GerenciadorFase.quantidadeMoedas = 0;
        }
    }
}
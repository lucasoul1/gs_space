using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private Game_over gameOver;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Tomando Dano volta a Fase
        if (collision.gameObject.tag == "Astronauta")
        {
            gameOver.GameOver = true;
            GerenciadorFase.quantidadeMoedas = 0;
        }
    }
}

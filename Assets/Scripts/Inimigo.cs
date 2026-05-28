using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Tomando Dano volta a Fase
        if (collision.gameObject.tag == "Astronauta")
        {
            // Atualizando Vidas do Jogador
            Astronauta.vidas--;
            print("Vidas: " + Astronauta.vidas);

            // Resetando Moedas do Jogador
            GerenciadorFase.quantidadeMoedas = 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

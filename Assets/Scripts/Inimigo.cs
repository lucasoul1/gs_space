using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private float velocidade = 2f; 

    void Update()
    {
        transform.Translate(velocidade * Time.deltaTime, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Parede")
        {
            // A serra inverte a direção;
            velocidade *= -1;
        }

        if (collision.gameObject.tag == "Astronauta")
        {
            // Atualizando Vidas do Jogador
            Astronauta.vidas--;
            print(Astronauta.vidas);

            // Resetando Moedas do Jogador
            GerenciadorFase.quantidadeMoedas = 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

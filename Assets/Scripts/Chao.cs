using UnityEngine;

public class Chao : MonoBehaviour
{

    public GerenciadorFase gerenciador;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Astronauta"))
        {
            Astronauta.estaNoChao = true;

            if(gerenciador.FaseDeIda == true)
            {
            
            gerenciador.carregarProximaFase();

            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Astronauta"))
        {
            Astronauta.estaNoChao = false;
        }
    }
}

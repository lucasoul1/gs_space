using UnityEngine;

public class Chao : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Astronauta"))
        {
            Astronauta.estaNoChao = true;
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

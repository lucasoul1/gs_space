using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{


  public void iniciar()
    {
        SceneManager.LoadScene("Fase01");

    }

    public void Sair()
    {
        Application.Quit();
        print("voce saiu");
    }
}

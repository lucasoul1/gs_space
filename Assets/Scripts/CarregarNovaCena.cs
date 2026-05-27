using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarNovaCena : MonoBehaviour
{
    public void CarregarProximaCena()
    {
        int cenaAtual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cenaAtual + 1);
    }
}
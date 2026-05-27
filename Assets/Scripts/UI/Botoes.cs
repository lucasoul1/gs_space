using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{

    [SerializeField] private GameObject MenuPrincipal;
    [SerializeField] private GameObject MenuOpcoes;

    public void iniciar()
    {
        SceneManager.LoadScene("Fase01");

    }
    public void abrirOpcoes()
     {
        MenuPrincipal.SetActive(false);
        MenuOpcoes.SetActive(true);
     }
    
    public void fecharOpcoes()
    {
        MenuPrincipal.SetActive(true);
        MenuOpcoes.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
        print("voce saiu");
    }
}

using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{

    [SerializeField] private GameObject MenuPrincipal;
    [SerializeField] private GameObject MenuOpcoes;

    public void iniciar()
    {
        SceneManager.LoadScene("LuaIda");
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

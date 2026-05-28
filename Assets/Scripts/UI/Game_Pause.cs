using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseGame;

    private bool JogoPausado;
    
    void Start()
    {
        PauseGame.SetActive(false);
    }

    public void StartPause()
    {
        PauseGame.SetActive(true);

         Time.timeScale = 0f;
         JogoPausado = true;
    }

        public void EndPause()
    {
        PauseGame.SetActive(false);

         Time.timeScale = 1f;
         JogoPausado = false;
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class Game_Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseGame;

    private bool JogoPausado = false;
    
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
}

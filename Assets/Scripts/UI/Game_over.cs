using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over : MonoBehaviour
{
    public GameObject TelaGameOver;
    public bool GameOver = false;

    void Start()
    {
        Time.timeScale = 1f;
        TelaGameOver.SetActive(false);
    }

    void Update()
    {
        if(GameOver == true){
            
        Time.timeScale = 0f;
        TelaGameOver.SetActive(true);

        }
    }

    public void recomecar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

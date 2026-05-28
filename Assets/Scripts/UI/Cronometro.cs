using TMPro;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    [SerializeField] private TMP_Text textoTimer;
    private float tempo;

    void Start()
    {
        tempo = 0;
    }

    void Update()
    {
        tempo += Time.deltaTime;
        AtualizarHUD();
    }

    void AtualizarHUD()
    {
        int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(tempo % 60);
        int milesimos = Mathf.FloorToInt((tempo * 1000) % 1000);

        textoTimer.text = string.Format("{0:00}:{1:00}:{2:000}",
            minutos,
            segundos,
            milesimos);
    }
}

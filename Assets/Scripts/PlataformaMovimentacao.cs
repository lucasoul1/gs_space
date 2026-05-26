using UnityEngine;

public class PlataformaMovimentacao : MonoBehaviour
{
    [SerializeField] private float velocidade = 1f;
    void Start()
    { 
    }

    void Update()
    {
        transform.Translate(velocidade * Time.deltaTime, 0f, 0f);

        if (transform.position.x >= 1f || transform.position.x <= -1f)
        {
            velocidade *= -1;
        }
    }
}

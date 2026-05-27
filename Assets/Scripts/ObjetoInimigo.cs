using UnityEngine;

public class ObjetoInimigo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidade = 2f; 
    
    void Start()
    {
        transform.position = new Vector2(0f, 1.35f);
    }

    void Update()
    {
        transform.Translate(velocidade * Time.deltaTime, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Parede")
        {
            // A serra inverte a direção;
            velocidade *= -1;
        }
    }
}

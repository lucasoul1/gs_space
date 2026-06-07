using UnityEngine;
using UnityEngine.SceneManagement;

public class Astronauta : MonoBehaviour
{
    // Atributos
    [SerializeField] private float velocidade = 3f;
    [SerializeField] private float forcaPulo = 6f;

    // Movimenta��o
    private float mover_x;

    // Propriedades
    private Rigidbody2D rb;
    public static bool estaNoChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        // Movimenta��o
        mover_x = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(mover_x, 0f, 0f);

        // Pulo
        if (estaNoChao && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
    }
}
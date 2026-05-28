using UnityEngine;
using UnityEngine.SceneManagement;

public class Astronauta : MonoBehaviour
{
    // Atributos
    [SerializeField] private float velocidade = 3f;
    public static int vidas = 3;
    [SerializeField] private float forcaPulo = 6f;
    
    // Movimentação
    private float mover_x;

    // Propriedades
    private Rigidbody2D rb;
    public static bool estaNoChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(0f, -3.835f);
    }

    void Update()
    {
        // Movimentação
        mover_x = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(mover_x, 0f, 0f);

        // Pulo 
        if (estaNoChao && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
    }

    
}

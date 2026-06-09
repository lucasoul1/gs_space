using UnityEngine;
using UnityEngine.SceneManagement;

public class Astronauta : MonoBehaviour
{
    // Atributos
    [SerializeField] private float velocidade = 3f;
    [SerializeField] private float forcaPulo = 6f;
    [SerializeField] private Animator animacao;

    // Movimenta��o
    private float mover_x;

    // Propriedades
    private Rigidbody2D rb;
    public static bool estaNoChao;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimentação
        mover_x = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(mover_x, 0f, 0f);

        //Animação
        if (mover_x != 0)
        {
            animacao.SetBool("TaAndando", true);
        }
        else
        {
            animacao.SetBool("TaAndando", false);
        }

        // Pulo
        if (estaNoChao && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }

        // Virar Sprite
        if (mover_x > 0)
        {
            sr.flipX = false;
        }
        else if (mover_x < 0)
        {
            sr.flipX = true;
        }
    }
}
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
    private bool estaNoChao;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se está no chão
        if (collision.gameObject.tag == "Chao" || collision.gameObject.tag == "Plataforma" || collision.gameObject.tag == "PlataformaSome")
        {
            estaNoChao = true;
        }

        // Colisão com Armadilhas
        if (collision.gameObject.tag == "Serra")
        {
            vidas--;
            print(vidas);
            SceneManager.LoadScene("GameScene");
        }


        // Sumir Plataforma
        if (collision.gameObject.tag == "PlataformaSome")
        {
            Destroy(collision.gameObject, 2f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verifica se saiu do chão
        if (collision.gameObject.tag == "Chao" || collision.gameObject.tag == "Plataforma")
        {
            estaNoChao = false;
        }
    }
}

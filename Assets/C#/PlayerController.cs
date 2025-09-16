using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerAnime anime;
    Transform tr;
    PlayerHP hp;

    

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb; // Можно назначить в инспекторе для удобства


    private bool isGrounded; // Переименовали для ясности
    private bool isDead; // Переименовали для ясности
    private float horizontalMove;

    private void Awake()
    {
        // Если rb не назначено в инспекторе, получаем его здесь
        hp = GetComponent<PlayerHP>();
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        anime = GetComponent<PlayerAnime>();    
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        isDead = hp.isDead;
        // Считываем ввод в Update
        if (!isDead)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
        }
       

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isDead)
        {
            Jump();
            
        }
        Turn(horizontalMove);
    }

    private void FixedUpdate()
    {
        // Используем сохранённое значение в FixedUpdate
        Move(horizontalMove);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Желательно проверять, с чем именно происходит столкновение,
        // например, по тегу "Ground".
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anime.JumpAnim();
    }

    public void Move(float x)
    {
        // Сохраняем текущую вертикальную скорость
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        anime.MoveAnim(x);
    }
    private void Turn(float x )
    {
        if (x > 0)
        {
            tr.localScale = new Vector2(1, 1);
        }
        else if (x < 1)
        {
            tr.localScale = new Vector2(-1, 1);
        }
    }
    
}
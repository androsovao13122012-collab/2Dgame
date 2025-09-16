using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerAnime anime;
    Transform tr;
    PlayerHP hp;

    

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb; // ����� ��������� � ���������� ��� ��������


    private bool isGrounded; // ������������� ��� �������
    private bool isDead; // ������������� ��� �������
    private float horizontalMove;

    private void Awake()
    {
        // ���� rb �� ��������� � ����������, �������� ��� �����
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
        // ��������� ���� � Update
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
        // ���������� ���������� �������� � FixedUpdate
        Move(horizontalMove);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������� ���������, � ��� ������ ���������� ������������,
        // ��������, �� ���� "Ground".
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
        // ��������� ������� ������������ ��������
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
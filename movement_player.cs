using UnityEngine;


public class movement_player : MonoBehaviour
{

    public GameObject interactionIcon;


    private bool isGrounded= true;
    private Rigidbody2D rb;
    float horizontal;
    public float moveSpeed = 15f;
    public float jumpAmount = 10;
    public Animator animator;
    public SpriteRenderer sprite;

    private Vector2 boxSize = new Vector2(0.1f, 1f);
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        interactionIcon.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            checkInteraction();

        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(horizontal *moveSpeed));
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (horizontal < 0)
        {
            sprite.flipX = true;
        }
        if(horizontal > 0)
        {
            sprite.flipX = false;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground" && isGrounded == false)
        {
            isGrounded = true;
        }
    }

    public void openInteractebleIcon()
    {
        interactionIcon.SetActive(true);
    }
    public void closeInteractebleIcon()
    {
        interactionIcon.SetActive(false);
    }
    private void checkInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.isInteractable())
                {
                    rc.interact();
                    return;
                }
            }
        }
    }
}
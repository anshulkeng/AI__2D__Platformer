using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private Animator anim;   // NEW → link animator

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();   // NEW
    }

    void Update()
    {
        float move = 0f;

        // -------- MOVEMENT --------
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            move = -1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            move = 1f;

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // -------- FLIP SPRITE --------
        if (move > 0.1f) transform.localScale = new Vector3(1, 1, 1);
        else if (move < -0.1f) transform.localScale = new Vector3(-1, 1, 1);

        // -------- ANIMATION (NEW) --------
        bool isRunning = Mathf.Abs(move) > 0.1f;
        anim.SetBool("isRunning", isRunning);   // connects to Animator parameter



        // -------- JUMP --------
        if (Input.GetKeyDown(KeyCode.Space))
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}

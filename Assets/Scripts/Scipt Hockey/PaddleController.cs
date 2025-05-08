using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float BatasAtas; 
    public float BatasBawah; 
    public float BatasKanan;
    public float BatasKiri;
    public float kecepatan; 
    public string Verticalaxis;
    public string Horizontalaxis;
    private bool IsFacingRight = true;
    private bool canDash= true;
    private bool IsDashing;
    private float dashingPower = 12f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    public KeyCode dashKey = KeyCode.LeftShift;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDashing)
        {
            return;
        }
        //Movement
        float gerakVertical = Input.GetAxis(Verticalaxis) * kecepatan * Time.deltaTime; 
        float gerakHorizontal = Input.GetAxis(Horizontalaxis) * kecepatan * Time.deltaTime; 
        float nextPos1 = transform.position.y + gerakVertical; 
        float nextPos2 = transform.position.x + gerakHorizontal; 
        if (nextPos1 > BatasAtas) 
        { 
            gerakVertical = 0; 
        } 
        if (nextPos1 < BatasBawah) 
        { 
            gerakVertical = 0; 
        } 
        if (nextPos2 > BatasKanan) 
        { 
            gerakHorizontal = 0; 
        } 
        if (nextPos2 < BatasKiri) 
        { 
            gerakHorizontal = 0; 
        } 

        flip(Input.GetAxis(Horizontalaxis)); 
        transform.Translate(gerakHorizontal, gerakVertical, 0);

        //Dash Trigger
        if (Input.GetKeyDown(dashKey) && canDash)
        {
            StartCoroutine(Dash());
        }
        //Batasi posisi saat dash
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, BatasKiri, BatasKanan);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, BatasBawah, BatasAtas);
        transform.position = clampedPosition;
    }
    

    private void flip(float arah)
    {
        if (IsFacingRight && arah < 0f || !IsFacingRight && arah > 0f )
        {
            IsFacingRight = !IsFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        IsDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Ambil input arah saat ini
        float dashX = Input.GetAxisRaw(Horizontalaxis);
        float dashY = Input.GetAxisRaw(Verticalaxis);
        Vector2 dashDirection = new Vector2(dashX, dashY).normalized;

        // Jika tidak ada input (0,0), default ke arah kanan atau kiri sesuai arah hadap
        if (dashDirection == Vector2.zero)
        {
        dashDirection = IsFacingRight ? Vector2.right : Vector2.left;
        }

        rb.velocity = dashDirection * dashingPower;
        tr.emitting = true;

        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = originalGravity;
        IsDashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    if (collision.gameObject.CompareTag("Bola") && IsDashing)
        {
        Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
            // Tambahkan kekuatan ekstra ke arah pantulan saat dash
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            float dashBoost = 1.5f; // bisa disesuaikan
            ballRb.velocity = direction * ballRb.velocity.magnitude * dashBoost;

            // Kembalikan kecepatan normal setelah beberapa saat
            StartCoroutine(ResetBallSpeed(ballRb, 1.5f)); // reset dalam 1.5 detik
            }
        }
    }

    private IEnumerator ResetBallSpeed(Rigidbody2D ballRb, float delay)
    {
    yield return new WaitForSeconds(delay);

        if (ballRb != null)
        {
        float maxSpeed = 8f; // batas kecepatan normal bola
        ballRb.velocity = ballRb.velocity.normalized * Mathf.Min(ballRb.velocity.magnitude, maxSpeed);
        }
    }
}
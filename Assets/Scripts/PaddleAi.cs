using System.Collections;
using UnityEngine;

public class PaddleAIController : MonoBehaviour
{
    public Transform ball;
    public float kecepatan = 5f;
    public float dashingPower = 12f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    public float BatasAtas, BatasBawah, BatasKiri, BatasKanan;
    private bool IsFacingRight = true;
    private bool isDashing = false;
    private bool canDash = true;

    private Rigidbody2D rb;
    private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (ball == null || isDashing) return;

        Vector2 targetPos = ball.position;
        Vector2 currentPos = transform.position;

        Vector2 arah = (targetPos - currentPos).normalized;
        float gerakX = arah.x * kecepatan * Time.deltaTime;
        float gerakY = arah.y * kecepatan * Time.deltaTime;

        // Cek batas peta
        float nextX = transform.position.x + gerakX;
        float nextY = transform.position.y + gerakY;

        if (nextX > BatasKanan || nextX < BatasKiri) gerakX = 0;
        if (nextY > BatasAtas || nextY < BatasBawah) gerakY = 0;

        transform.Translate(gerakX, gerakY, 0);

        // Flip
        if (arah.x < 0 && IsFacingRight || arah.x > 0 && !IsFacingRight)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        // AI Dash sesekali
        if (canDash && Vector2.Distance(transform.position, ball.position) < 3f && Random.value < 0.01f)
        {
            StartCoroutine(Dash(arah));
        }
    }

    IEnumerator Dash(Vector2 arah)
    {
        isDashing = true;
        canDash = false;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = arah * dashingPower;
        if (tr != null) tr.emitting = true;

        yield return new WaitForSeconds(dashingTime);

        rb.velocity = Vector2.zero;
        rb.gravityScale = originalGravity;
        if (tr != null) tr.emitting = false;
        isDashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

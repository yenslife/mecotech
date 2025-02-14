using UnityEngine;

public class FemaleController : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 1f;  // 增加速度
    public float rotationSpeed = 100f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 0;  // 確保沒有阻力
        // rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // 防止跌倒
    }

    void FixedUpdate()  // 用 FixedUpdate 控制剛體運動
    {
        float moveZ = Input.GetAxis("Vertical");  // W/S 或 ↑/↓
        float rotateX = Input.GetAxis("Horizontal");  // A/D 或 ←/→

        // **檢查是否處於 Idle 並按下轉向鍵**
        if (moveZ == 0 && Mathf.Abs(rotateX) > 0.1f)
        {
            if (rotateX < 0) // 按 A（←）
            {
                animator.SetBool("isTurningLeft", true);
                transform.Rotate(Vector3.up * rotateX * rotationSpeed * Time.fixedDeltaTime);
            }
            else if (rotateX > 0) // 按 D（→）
            {
                animator.SetBool("isTurningRight", true);
                transform.Rotate(Vector3.up * rotateX * rotationSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            animator.SetBool("isTurningLeft", false);
            animator.SetBool("isTurningRight", false);
        }

        // **處理前進 & 後退**
        Vector3 move = transform.forward * moveZ;

        if (Mathf.Abs(moveZ) > 0.1f)
        {
            // rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
            rb.linearVelocity = move * moveSpeed;

            if (moveZ > 0)  // **前進**
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalkingBackward", false);
            }
            else  // **後退**
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalkingBackward", true);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalkingBackward", false);
        }

        // **角色旋轉（非 Idle 狀態才旋轉）**
        if (Mathf.Abs(rotateX) > 0.1f && moveZ != 0)
        {
            transform.Rotate(Vector3.up * rotateX * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}

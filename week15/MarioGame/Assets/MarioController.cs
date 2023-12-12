using UnityEngine;

public class MarioController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 플레이어의 지상 여부를 확인
        isGrounded = characterController.isGrounded;

        // 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f);
        moveDirection = transform.TransformDirection(moveDirection);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // 점프
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(2f * jumpForce * Mathf.Abs(Physics.gravity.y));
        }

        // 중력 적용
        velocity.y += Physics.gravity.y * Time.deltaTime;

        // 이동 속도 적용
        characterController.Move(velocity * Time.deltaTime);
    }
}

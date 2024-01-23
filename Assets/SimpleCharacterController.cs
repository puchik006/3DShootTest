using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        MoveCharacter(movement);
    }

    void MoveCharacter(Vector3 direction)
    {
        Vector3 movementAmount = direction * movementSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movementAmount);
    }
}

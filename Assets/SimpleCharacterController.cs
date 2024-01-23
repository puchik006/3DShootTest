using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Rigidbody rb;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    private void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector3 direction)
    {
        Vector3 movementAmount = direction * movementSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movementAmount);
    }
}

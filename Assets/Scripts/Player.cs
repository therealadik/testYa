using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private bool isJumpTriggered = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = _speed;
        _rigidbody.velocity = velocity;

        if (isJumpTriggered)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void OnJump(InputValue inputValue)
    {
        isJumpTriggered = inputValue.isPressed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string otherTag = collision.tag;
        print(otherTag);
    }
}

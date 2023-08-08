using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public float Score { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private string _obstacleTag;

    [SerializeField] private TMP_Text _moneyText;

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

        if (otherTag == _obstacleTag)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddCoin(int value)
    {
        Score += value;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _moneyText.text = Score.ToString();
    }

}

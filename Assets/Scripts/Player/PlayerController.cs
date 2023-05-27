using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _movement;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement.normalized * _speed * Time.fixedDeltaTime);
    }
}

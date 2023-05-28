using UnityEngine;

public class Potatoe : MonoBehaviour
{
	[SerializeField] private Vector2 _force;
	[SerializeField] private int _damage;
	[SerializeField] private float _lifeTime;
	[SerializeField] private float _boomDistance;
	private PlayerHealth _player;
	private Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_player = FindObjectOfType<PlayerHealth>();
	}

	public void Punch(Vector2 direction)
	{
		_rb.AddForce(direction * _force);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == _player.name)
		{
			_player.ApplyDamage(_damage);
			Destroy(gameObject);
		}
	}
}

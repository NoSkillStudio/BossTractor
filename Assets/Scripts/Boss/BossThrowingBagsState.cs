using UnityEngine;
using GD.MinMaxSlider;

public class BossThrowingBagsState : BossBaseState
{
	[Header("Bag Settings")]

	[SerializeField]
	[MinMaxSlider(3, 10)]
	private Vector2Int _potatoesCount;
	[SerializeField] private float _timeToSpawn;
	[SerializeField] private GameObject _bag;

	[Header("Settings")]

	[SerializeField] private float _speed = 1f;
	private Transform _player;
	private SpriteRenderer spriteRenderer;

	private float _timer;

	private void SpawnBag()
	{
		int potatoesCount = Random.Range(_potatoesCount.x, _potatoesCount.y);
		Bag bag = Instantiate(_bag, transform.position, Quaternion.identity).GetComponent<Bag>();
		StartCoroutine(bag.Jump(transform.position, potatoesCount));
	}

	public override void EnterState(BossStateManager boss)
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		_timer = _timeToSpawn;
	}

	public override void UpdateState(BossStateManager boss)
	{
		_timer -= Time.deltaTime;
		if (_timer <= 0)
		{
			_timer = _timeToSpawn;
			SpawnBag();
		}
	}

	public override void OnCollisionEnter2D(Collision2D boss)
	{

	}
}

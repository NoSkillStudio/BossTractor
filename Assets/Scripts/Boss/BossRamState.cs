using UnityEngine;

public class BossRamState : BossBaseState
{
	[SerializeField] private float speed = 1f;
	private Transform _player;
	private SpriteRenderer spriteRenderer;

	public override void EnterState(BossStateManager boss)
	{
		//TODO: анимация обнаружения
		_player = FindObjectOfType<PlayerController>().transform;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	public override void UpdateState(BossStateManager boss)
	{
		Vector2 targetPosition = _player.position;
		if (targetPosition.x >= transform.position.x)
			spriteRenderer.flipX = false;
		else spriteRenderer.flipX = true;

		transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
	}

	public override void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
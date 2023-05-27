using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossRamState : BossBaseState
{
	[SerializeField] private Transform playerPosition;
    private Vector3 targetPosition;
    [SerializeField] private float speed = 1f;
    private void Start()
	{
		
	}

	private void Update()
	{
		
	}
	public override void EnterState(BossStateManager boss)
	{
		//TODO: анимация обнаружения
		targetPosition = playerPosition.position;
	}
	public override void UpdateState(BossStateManager boss)
	{
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
    }

	public override void OnCollisionEnter2D(Collision2D boss)
	{
		
	}


}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossFollowState : BossBaseState
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float speed = 1f;

    public override void EnterState(BossStateManager boss)
    {
       
    }
    public override void UpdateState(BossStateManager boss)
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.fixedDeltaTime);
    }

    public override void OnCollisionEnter2D(Collision2D boss)
    {
        
    }
}
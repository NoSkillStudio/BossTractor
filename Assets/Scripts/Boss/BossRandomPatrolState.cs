using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossRandomPatrolState : BossBaseState
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float stopDistance = 0.1f;
    [SerializeField] private float minimumDistance = 0.1f;

    private bool isMoving = true;
    private Vector3 targetPosition;
    [SerializeField] private Transform playerPosition;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ChangeTarget();
    }

    private void Move()
    {
        if (isMoving)
        {
            if (targetPosition.x >= transform.position.x)
                spriteRenderer.flipX = false;
            else spriteRenderer.flipX = true;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);


            if (Vector2.Distance(transform.position, playerPosition.position) < stopDistance)
            {
                isMoving = false;
                Invoke("ChangeTarget", 1f);
            }

            if (Vector2.Distance(transform.position, targetPosition) < minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, -speed * Time.fixedDeltaTime);
                ChangeTarget();
            }
        }
    }
    public override void EnterState(BossStateManager boss)
    {
        StartMove();
    }

    public override void UpdateState(BossStateManager boss)
    {
        Move();
    }
    public override void OnCollisionEnter2D(Collision2D boss)
    {

    }
    public void ChangeTarget()
    {
        targetPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-3f, 3f), 0);
        isMoving = true;
    }
    public void StopMove()
    {
        targetPosition = transform.position;
        isMoving = false;
    }

    public void StartMove()
    {
        isMoving = true;
    }

}
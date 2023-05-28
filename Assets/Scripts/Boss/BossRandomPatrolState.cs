using UnityEngine;

public class BossRandomPatrolState : BossBaseState
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float stopDistance = 0.1f;
    [SerializeField] private float minimumDistance = 0.1f;
    [SerializeField] private Transform _player;
    private bool isMoving = true;
    private Vector3 targetPosition;
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
            if (Vector2.Distance(transform.position, _player.position) <= minimumDistance)
            {
                //transform.position = Vector2.MoveTowards(transform.position, targetPosition, -speed * Time.fixedDeltaTime);
                //isMoving = false;
                ChangeTarget();
            }

            if (Vector2.Distance(transform.position, targetPosition) < stopDistance)
            {
                isMoving = false;
                Invoke(nameof(ChangeTarget), 1f);
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

    public override void OnCollisionEnter2D(Collision2D collision)
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

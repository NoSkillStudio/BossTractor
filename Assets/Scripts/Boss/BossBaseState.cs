using Unity.VisualScripting;
using UnityEngine;

public abstract class BossBaseState : MonoBehaviour
{
    public abstract void EnterState(BossStateManager boss);

    public abstract void UpdateState(BossStateManager boss);

    public abstract void OnCollisionEnter2D(Collision2D boss);
}
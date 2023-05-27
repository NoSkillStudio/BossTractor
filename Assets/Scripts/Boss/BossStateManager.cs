using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    BossBaseState currentState;
    public BossRandomPatrolState RandomPatrolState;
    private void Start()
    {
        currentState = RandomPatrolState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BossBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(collision);
    }
}
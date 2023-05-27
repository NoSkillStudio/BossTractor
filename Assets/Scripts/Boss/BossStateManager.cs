using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    BossBaseState currentState;
    [SerializeField] private BossRandomPatrolState RandomPatrolState;
    [SerializeField] private BossRamState RamState;
    private void Start()
    {
        currentState = RandomPatrolState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwitchState(RandomPatrolState);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwitchState(RamState);
        }
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
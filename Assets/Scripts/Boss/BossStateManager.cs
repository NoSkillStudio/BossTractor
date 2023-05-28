using UnityEngine;

public class BossStateManager : MonoBehaviour
{
	BossBaseState currentState;
	[SerializeField] private BossRandomPatrolState RandomPatrolState;
	[SerializeField] private BossRamState RamState;
	[SerializeField] private BossFollowState FollowState;
	[SerializeField] private BossThrowingBagsState ThrowingBagsState;
	private void Start()
	{
		currentState = RandomPatrolState;
		currentState.EnterState(this);
	}

	private void Update()
	{
		currentState.UpdateState(this);

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SwitchState(RandomPatrolState);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			SwitchState(RamState);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			SwitchState(FollowState);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			SwitchState(ThrowingBagsState);
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
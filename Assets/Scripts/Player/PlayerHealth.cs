using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	[SerializeField] private Image _healthBar;
	[Range(1, 20)]
	[SerializeField]
	private int _maxHealth;
	private int _health;
	private bool _alive = true;

	private void Start()
	{
		_health = _maxHealth;
	}

	private IEnumerator ChangeValue(int oldHealth, float time)
	{
		float a = ((float) oldHealth / (float) _maxHealth);
		float b = ((float) _health / (float) _maxHealth);

		for (float t = 0f; t < time; t += 0.01f)
		{
			_healthBar.fillAmount = Mathf.Lerp(a, b, t);
			yield return new WaitForSeconds(0.01f);
		}
	}

	public void ApplyDamage(int damageValue)
	{
		int oldHealth = _health;
		_health -= damageValue;
		StartCoroutine(ChangeValue(oldHealth, 0.1f));
		if (_alive && _health <= 0)
		{
			Die();
		}
	}

	public void Die()
	{
		_alive = false;
		GetComponent<PlayerController>().enabled = false; // PlayerController нужен только один раз
	}
}

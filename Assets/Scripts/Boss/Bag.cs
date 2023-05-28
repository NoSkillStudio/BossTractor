using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Bag : MonoBehaviour
{
	[SerializeField] private GameObject _potatoePrefab;
	[SerializeField] private int _damage;
	[SerializeField] private float _boomDistance;
	[SerializeField] private float _timeToBoom;
	[SerializeField] private float _jumpDistance;
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _jumpTime;
	private ParticleSystem _particle;
	private PlayerHealth _player;

	private void Start()
	{
		_player = FindObjectOfType<PlayerHealth>();
		_particle = GetComponent<ParticleSystem>();
	}

	public IEnumerator Jump(Vector2 oldBossPosition, int potatoesCount)
	{
		float direction = Mathf.Sign(Random.Range(-1, 0));
		float stepTime = _jumpTime * 0.01f;
		Vector2 p0 = oldBossPosition;
		Vector2 p1 = p0 + new Vector2(direction * _jumpDistance * 0.33f, _jumpForce);
		Vector2 p2 = p0 + new Vector2(direction * _jumpDistance * 0.66f, _jumpForce);
		Vector2 p3 = p0 + new Vector2(direction * _jumpDistance, 0);
		for (float t = 0; t < 1; t += 0.01f)
		{
			transform.position = Bezier.GetPoint(p0, p1, p2, p3, t);
			yield return new WaitForSeconds(stepTime);
		}
		StartCoroutine(Boom(potatoesCount));
	}

	private IEnumerator SpawnPotatoes(int potatoesCount)
	{
		for (int i = 0; i < potatoesCount; i++)
		{
			print("Spawning");
			Vector2 direction = new Vector2(Mathf.Sign(Random.Range(-1, 0)), Random.Range(-1f, 1f));
			Potatoe potatoe = Instantiate(
				_potatoePrefab,
				transform.position,
				Quaternion.identity
			).GetComponent<Potatoe>();
			potatoe.Punch(direction);
			print("Done");
		}
		yield break;
	}

	private IEnumerator Boom(int potatoesCount)
	{
		yield return new WaitForSeconds(_timeToBoom);
		_particle.Play();
		if (Vector2.Distance(transform.position, _player.transform.position) <= _boomDistance)
		{
			_player.ApplyDamage(_damage);
		}
		print("Ok");
		StartCoroutine(SpawnPotatoes(potatoesCount));
		while (_particle.isPlaying) { /* do nothing */ }
		Destroy(gameObject);
	}
}

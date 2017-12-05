using UnityEngine;
using Gemserk;
using Gemserk.Signals;

public class GameCharacter : MonoBehaviour
{
	public Example1SignalChannel charactedDiedChannel;

	public InterfaceReference characterLoseHealthChannel;

	bool _isDead;

	public float totalHealth = 100;
	public float damage = 20;

	public KeyCode killKey = KeyCode.Alpha1;

	void Update()
	{
		if (_isDead)
			return;
		
		if (Input.GetKeyUp(killKey)) {
			totalHealth -= damage;

			if (totalHealth <= 0) {
				_isDead = true;
				charactedDiedChannel.Get ().Signal (this.gameObject);
			} else {
			
				var health = new Health () {
					current = totalHealth,
					unit = this.gameObject
				};
				characterLoseHealthChannel.Get<ISignalChannel<Health>> ().Signal (health);
			
				totalHealth = health.current;
			}
		}
	}
}

using UnityEngine;

public class HealthScript : MonoBehaviour {

	public int hp = 1;

	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	
	void Awake() {
		if (!isEnemy)
		{
			AppData.CurrentHealth = hp;
		}
	}
	
	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		if (!isEnemy)
		{
			AppData.CurrentHealth = hp;
		}
	
		if (hp <= 0)
		{
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();
			if (isEnemy)
				AppData.CurrentScore += 2;
		// Dead!
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		BulletScript shot = otherCollider.gameObject.GetComponent<BulletScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
		
				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
		BonusScript bonus = otherCollider.gameObject.GetComponent<BonusScript>();
		if (bonus != null)
		{
			if (!isEnemy)
			{
				AppData.CurrentScore += 1;
				Destroy(bonus.gameObject);
			}
		}
		BulletBonusScript bulletBonus = otherCollider.gameObject.GetComponent<BulletBonusScript>();
		if (bulletBonus != null)
		{
			if (!isEnemy)
			{
				if (AppData.shootType == AppData.ShootType.One){
					AppData.shootType = AppData.ShootType.Two;
				} else {
					AppData.shootType = AppData.ShootType.Three;
				}
				Destroy(bulletBonus.gameObject);
			}
		}
	}
	
}

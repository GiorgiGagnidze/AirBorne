using UnityEngine;

public class PlayerScript : MonoBehaviour {

	 public Vector2 speed = new Vector2(50, 50);

  // 2 - Store the movement
    private Vector2 movement;

    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
    
        // 4 - Movement per direction
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Jump");
        shoot |= Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        // Careful: For Mac users, ctrl + arrow is a bad idea
    
        if (shoot)
        {
            WeaponScript[] weapons = GetComponentsInChildren<WeaponScript>();
            if (weapons != null){
                for (int i = 0; i < weapons.Length; i++)
                {
                    if (weapons[i] != null)
                    {
                    // false because the player is not an enemy
                        switch (weapons[i].name ) {
                            case "Weapon0": 
                                if (AppData.shootType == AppData.ShootType.One || AppData.shootType == AppData.ShootType.Three)
                                    weapons[i].Attack(false);
                                break;
                            case "Weapon1":
                                if (AppData.shootType == AppData.ShootType.Two || AppData.shootType == AppData.ShootType.Three)
                                    weapons[i].Attack(false);
                                break;
                            case "Weapon2":
                                if (AppData.shootType == AppData.ShootType.Two || AppData.shootType == AppData.ShootType.Three)
                                    weapons[i].Attack(false);
                                break;
                        }
                    }
                }
                SoundEffectsHelper.Instance.MakePlayerShotSound();
            }
        }
        
        // 6 - Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;
    
        var leftBorder = Camera.main.ViewportToWorldPoint(
        new Vector3(0, 0, dist)
        ).x;
    
        var rightBorder = Camera.main.ViewportToWorldPoint(
        new Vector3(1, 0, dist)
        ).x;
    
        var topBorder = Camera.main.ViewportToWorldPoint(
        new Vector3(0, 0, dist)
        ).y;
    
        var bottomBorder = Camera.main.ViewportToWorldPoint(
        new Vector3(0, 1, dist)
        ).y;
    
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );
    }

    void FixedUpdate()
    {
        // 5 - Move the game object
        GetComponent<Rigidbody2D>().velocity = movement;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
  {
    bool damagePlayer = false;

    // Collision with enemy
    EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Kill the enemy
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
        
            damagePlayer = true;
        }
    
        // Damage the player
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }
    
    void OnDestroy()
    {
        // Game Over.
        // Add the script to the parent because the current game
        // object is likely going to be destroyed immediately.
        if (AppData.CurrentScore > AppData.Achievment)
            AppData.Achievment = AppData.CurrentScore;
        transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}

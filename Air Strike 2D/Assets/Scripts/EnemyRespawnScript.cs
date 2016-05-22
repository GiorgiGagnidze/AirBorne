using UnityEngine;

public class EnemyRespawnScript : MonoBehaviour {
	public Transform enemy1;
	public Transform enemy2;
	private System.Random random;
	
	void Start()
	{
		random = new System.Random();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount < 3)
		{
			var dist = (transform.position - Camera.main.transform.position).z;
    
			var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
			var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
			var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;			
		
			Vector3 position = new Vector3(
				random.Next((int)leftBorder,(int)rightBorder),
				bottomBorder+2,
				transform.position.z
			);
			Transform enemy;
			if (random.NextDouble()<0.5){
				enemy = enemy1;
			} else {
				enemy = enemy2;
			}
			Transform gobject = Instantiate(enemy, position, Quaternion.identity) as Transform;
			gobject.SetParent(transform);
			gobject.gameObject.SetActive(true);
		}
		
	}
}

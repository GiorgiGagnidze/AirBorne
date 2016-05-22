﻿using UnityEngine;

public class BonusRespawnScript : MonoBehaviour {

	public Transform bonus;
	private System.Random random;
	
	void Start()
	{
		random = new System.Random();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount < 5)
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
			Transform gobject = Instantiate(bonus, position, Quaternion.identity) as Transform;
			gobject.SetParent(transform);
			gobject.gameObject.SetActive(true);
		}
		
	}
}

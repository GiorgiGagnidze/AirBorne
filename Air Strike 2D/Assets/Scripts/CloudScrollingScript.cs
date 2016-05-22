using UnityEngine;

public class CloudScrollingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 0, dist)
		).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint(
		new Vector3(0, 1, dist)
		).y;
		if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false && transform.position.y < topBorder)
		{
		
			transform.position = new Vector3(
				transform.position.x,
				bottomBorder+5,
				transform.position.z
			);
		}
	}
}

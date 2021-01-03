using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MoveAndSpawnRoad : MonoBehaviour
{

	public float speed = 1.2f;
	public GameObject road;

	void Update() 
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);

		if (transform.position.y < -8f)
        {
			Instantiate(road, new Vector3(0, 7f, 0), Quaternion.identity);
			Destroy(gameObject);
		}
	}
}

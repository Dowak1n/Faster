using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGold : MonoBehaviour
{
	public GameObject[] gold;
	private float[] positions = { -1.61f, -0.58f, 0.44f, 1.49f };

	private void Start()
    {
		StartCoroutine(spawn());
	}

	IEnumerator spawn()
    {
		while (true)
        {
			Instantiate (
				gold[Random.Range(0, gold.Length)],
				new Vector3(positions[Random.Range(0,1)], 6f, 0),
				Quaternion.Euler(new Vector3(90,0,5))
			);
			yield return new WaitForSeconds(2.5f);
		}
	}
}

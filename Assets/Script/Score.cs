using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int Score_Player;
	public Text txt;

	private float timer;

	void Start()
    {
	}
	

	void Update()
    {
		txt.text = "Score: " + Score_Player;
		timer += 1 * Time.deltaTime;

		if (timer > 1) 
		{
			Score_Player += 1;
			timer = 0;
		}
	}
}

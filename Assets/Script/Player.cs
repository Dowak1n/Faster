using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;

public class Player : MonoBehaviour
{
	float speed = 3f;
	public Score sc;

	private void Update ()
    {
		float hor = Input.GetAxisRaw("Horizontal");

		Vector3 dir = new Vector3(hor, 0,0);
		transform.Translate(dir.normalized * Time.deltaTime * speed );
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Car"))
        {
			Destroy(gameObject);
			string connection = "URI=file:" + Application.persistentDataPath + "/Game2.db";
			IDbConnection dbcon = new SqliteConnection(connection);
			dbcon.Open();
			IDbCommand dbcmd;
			IDataReader reader;
			IDbCommand cmnd = dbcon.CreateCommand(); 
			cmnd.CommandText = string.Format("INSERT INTO score (name,point) values(\"{0}\",{1});","Lesha", sc.Score_Player);
			cmnd.ExecuteNonQuery();
			dbcon.Close();
			SceneManager.LoadScene(0);
		}
	}
}

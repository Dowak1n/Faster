using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Menu : MonoBehaviour
{
	public FirstTime ft;

	public void Start()
	{
        if (ft == null)
        {
            return;
        }
			
		ft.BD.Clear();

		string connection = "URI=file:" + Application.persistentDataPath + "/Game2.db";
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query = "SELECT * FROM score";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		while (reader.Read())
        {
			BDfisrst record = new BDfisrst();
			record.Id = Convert.ToInt32 (reader[0]);
			record.name = reader[1].ToString();
			record.score = Convert.ToInt32(reader[2]);
			ft.BD.Add(record);

			Debug.Log (record.Id.ToString()+record.name.ToString());
		}

		dbcon.Close();
	}

	public void ShowTable()
	{
		SceneManager.LoadScene(2);
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}
		
	public void ExitGame()
	{
		Application.Quit();
	}

	public void Back()
	{
		SceneManager.LoadScene(0);
	}
}

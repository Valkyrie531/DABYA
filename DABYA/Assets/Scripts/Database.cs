using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;


public class Database : MonoBehaviour
{
    private string conn;
    // Start is called before the first frame update
    void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/DAB-YA.s3db";//path to database
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the Database
        IDbCommand dbcmd = dbconn.CreateCommand();
        String sqlQuery = "SELECT * " + "FROM PlayerScore";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            
            String Name = reader.GetString(1);
            int Score = reader.GetInt32(2);
            var Date = reader.GetDateTime(3);

            Debug.Log("Name: " + Name + " Score: " + Score + " " + " Date:" + Date);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

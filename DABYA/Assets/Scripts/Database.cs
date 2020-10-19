using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;
using System.Data.Common;

public class Database : MonoBehaviour
{
    private string conn;

    public InputField enterName;

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


        public void EnterName() 
    {
        Debug.Log("Enter the name:" + enterName.text);

        if (enterName.text != string.Empty)
        {
            int Randscore = UnityEngine.Random.Range(1, 500);

            using (IDbConnection dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();

                using (IDbCommand dbcmd = dbconn.CreateCommand())
                {
                    string sqlQuery = String.Format("INSERT INTO PlayerScore(Player_Name,Score) VALUES(\"{0}\",\"{1}\")", enterName.text,Randscore);
                    dbcmd.CommandText = sqlQuery;
                    dbcmd.ExecuteScalar();
                    dbconn.Close();
                    enterName.text = string.Empty;
                }
            }
        }
    }

}

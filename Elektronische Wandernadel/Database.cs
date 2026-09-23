using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Elektronische_Wandernadel
{
    internal class Database
    {

        private const string ConnectionString = "Data Source=HWN_Datenbank.db";

        public void Initialisieren()
        {
            using SqliteConnection connection = new SqliteConnection(ConnectionString);
            connection.Open();

            string sql = @"CREATE TABLE IF NOT EXISTS Wandernadel (Id INTEGER PRIMARY KEY, HWNNr INTEGER NOT NULL CHECK (typeof(HWNNr) = 'integer'), Name TEXT NOT NULL, Erreicht TEXT, Stempel INTEGER CHECK (typeof(Stempel) = 'integer'));";

            using SqliteCommand command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public SqliteConnection DatenbankVerbinden()
        {
            SqliteConnection connection = new SqliteConnection(ConnectionString);
            connection.Open();
            return connection;

        }

        public void DeleteTabelle()
        {
            using SqliteConnection connection = new SqliteConnection(ConnectionString);
            connection.Open();

            string deleteTable = "DROP TABLE IF EXISTS Wandernadel;";

            using SqliteCommand deleteCommand = new SqliteCommand(deleteTable, connection);
            deleteCommand.ExecuteNonQuery();
        }
    }

}


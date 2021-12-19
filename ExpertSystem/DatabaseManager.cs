using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;


namespace SimpleFilter
{
    class DatabaseManager
    {
        public string connectionString;
        SqliteConnection connection;

        public DatabaseManager(string str)
        {
            connectionString = str;
            InitializeDatabase();
        }
        
        public void InitializeDatabase()
        {
            using (connection = new SqliteConnection(String.Format("Data Source={0}", connectionString)))
            {
                connection.Open();
                connection.Close();
            }
        }

        public void ExecuteCommand(string command)
        {
            using (var connection = new SqliteConnection(String.Format("Data Source={0}", connectionString)))
            {
                connection.Open();
                SqliteCommand com = connection.CreateCommand();
                com.CommandText = command;
                using (SqliteDataReader reader = com.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())   
                        {
                            var id = reader.GetValue(1);
                            Console.WriteLine($"{id}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Данный метод возвращает список всех ноутбуков из базы данных
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <returns>Список ноутбуков</returns>
        public List<Notebook> GetALLNotebooks(string query)
        {
            using (var connection = new SqliteConnection(String.Format("Data Source={0}", connectionString)))
            {
                connection.Open();
                SqliteCommand com = connection.CreateCommand();
                com.CommandText = query;
                List<Notebook> list = new List<Notebook>();
                using (SqliteDataReader reader = com.ExecuteReader())
                {
                    if (reader.HasRows) 
                    {
                        while (reader.Read()) 
                        {
                            var name = reader.GetValue(1);
                            var image = reader.GetValue(2);
                            var URL = reader.GetValue(3);
                            var usage = reader.GetValue(4);
                            var CPU = reader.GetValue(5);
                            var operativeSystem = reader.GetValue(6);
                            var hddType = reader.GetValue(7);
                            var hddSize = reader.GetValue(8);
                            var ram = reader.GetValue(9);
                            var videocardType = reader.GetValue(10);
                            var videocard = reader.GetValue(11);
                            var batteryLife = reader.GetValue(12);
                            var displayType = reader.GetValue(13);
                            var displayResolution = reader.GetValue(14);
                            var displayDiagonal = reader.GetValue(15);
                            var displayFrequency = reader.GetValue(16);
                            var canReplaceRAM = reader.GetValue(17);
                            var canReplaceHDD = reader.GetValue(18);
                            var hasOpticDrive = reader.GetValue(19); ;
                            var hasGSM = reader.GetValue(20);
                            Notebook notebook = new Notebook(name.ToString(), URL.ToString(), image.ToString(),usage.ToString(), operativeSystem.ToString(), hddType.ToString(), hddSize.ToString(), ram.ToString(), videocardType.ToString(), batteryLife.ToString(), displayType.ToString(), displayResolution.ToString(), displayDiagonal.ToString(), displayFrequency.ToString(), hasOpticDrive.ToString(), canReplaceRAM.ToString(), canReplaceHDD.ToString(), hasGSM.ToString(),CPU.ToString(),videocard.ToString());
                            list.Add(notebook);
                        }
                    }
                }
                return list;
            }
        }
    }
}

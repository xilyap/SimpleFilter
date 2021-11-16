using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using
    System.Linq;

namespace ExpertSystem
{
    class DatabaseManager
    {
        public string connectionString;
        public DatabaseManager(string str)
        {
            connectionString = str;
            InitializeDatabase();
        }
        SqliteConnection connection;
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
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var id = reader.GetValue(1);
                            Console.WriteLine($"{id}");
                        }
                    }
                }
            }
        }
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
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var name = reader.GetValue(1);
                            var image = reader.GetValue(2);
                            var URL = reader.GetValue(3);
                            var usage = reader.GetValue(4);
                            var operativeSystem = reader.GetValue(5);
                            var hddType = reader.GetValue(6);
                            var hddSize = reader.GetValue(7);
                            var ram = reader.GetValue(8);
                            var videocardType = reader.GetValue(9);
                            var batteryLife = reader.GetValue(10);
                            var displayType = reader.GetValue(11);
                            var displayResolution = reader.GetValue(12);
                            var displayDiagonal = reader.GetValue(13);
                            var displayFrequency = reader.GetValue(14);
                            var canReplaceRAM = reader.GetValue(15);
                            var canReplaceHDD = reader.GetValue(16);
                            var hasOpticDrive = reader.GetValue(17); ;
                            var hasGSM = reader.GetValue(18);
                            Notebook notebook = new Notebook(name.ToString(), URL.ToString(), image.ToString(),usage.ToString(), operativeSystem.ToString(), hddType.ToString(), hddSize.ToString(), ram.ToString(), videocardType.ToString(), batteryLife.ToString(), displayType.ToString(), displayResolution.ToString(), displayDiagonal.ToString(), displayFrequency.ToString(), hasOpticDrive.ToString(), canReplaceRAM.ToString(), canReplaceHDD.ToString(), hasGSM.ToString());
                            list.Add(notebook);
                        }
                    }
                }
                return list;
            }
        }
        public List<Question> GetALLQuestions()
        {
            using (var connection = new SqliteConnection(String.Format("Data Source={0}", connectionString)))
            {
                connection.Open();
                SqliteCommand com = connection.CreateCommand();
                com.CommandText = "SELECT * FROM Questions";
                List<Question> list = new List<Question>();
                using (SqliteDataReader reader = com.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var label = reader.GetValue(1);
                            var leftAnswer = reader.GetValue(2);
                            var rightAnswer = reader.GetValue(3);
                            int leftPath = reader.IsDBNull(4)? -1 : reader.GetInt32(4);
                            int rightPath = reader.IsDBNull(5) ? -1 : reader.GetInt32(5);
                            list.Add(new Question(label.ToString(), leftAnswer.ToString(),rightAnswer.ToString(), leftPath, rightPath));
                        }
                    }
                }
                return list;
            }
        }
    }
}

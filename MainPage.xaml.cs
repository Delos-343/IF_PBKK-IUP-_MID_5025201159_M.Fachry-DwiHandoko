using SQLite;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BMI_Calc_App
{
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection connection;

        public MainPage()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private async void InitializeDatabase()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "bmi.db");
            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<BMIRecord>();
        }

        private void OnCalculateBMI(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(weightEntry.Text) && !string.IsNullOrWhiteSpace(heightEntry.Text))
            {
                var weight = double.Parse(weightEntry.Text);
                var height = double.Parse(heightEntry.Text) / 100;
                var bmi = weight / (height * height);

                resultLabel.Text = $"Your BMI is {bmi:F1}";

                var record = new BMIRecord
                {
                    Weight = weight,
                    Height = height,
                    BMI = bmi,
                    Date = DateTime.Now
                };

                connection.InsertAsync(record);
            }
        }
    }

    public class BMIRecord
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI { get; set; }
        public DateTime Date { get; set; }
    }
}


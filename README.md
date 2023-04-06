# IF_PBKK-IUP-_MID_5025201159_M.Fachry-DwiHandoko
<br/><br/>
<h3> BMI Calculator App  :  .NET MAUI (C#) </h3>
<hr>

<br/>

```
SQLite-net-pcl
```

<p> Requires this NuGet Package </p>
<br/><br/>

```
<StackLayout>
    <Entry x:Name="weightEntry" Placeholder="Enter your weight in kg" />
    <Entry x:Name="heightEntry" Placeholder="Enter your height in cm" />
    <Button Text="Calculate BMI" Clicked="OnCalculateBMI" />
    <Label x:Name="resultLabel" />
</StackLayout>
```

<p> Figure 1.1 | Create the UI </p>
<br/> <br/>

```
using SQLite;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
```

<p> Figure 2.1 | Set up the app environment </p>
<br/> <br/>

```
namespace BMICalculator
    public partial class MainPage : ContentPage
        private SQLiteAsyncConnection connection
        public MainPage
            InitializeComponent
            InitializeDatabase
```

<p> Figure 2.2 | Initializing / rendering the app </p>
<br/> <br/>

```
        private async void InitializeDatabase()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "bmi.db");
            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<BMIRecord>();
        }
```

<p> Figure 2.3 | Initializing SQLite </p>
<br/> <br/>

```
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
```

<p> Figure 2.4 | Developing the logic for calculating User BMI </p>
<br/> <br/>

```
    public class BMIRecord
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI { get; set; }
        public DateTime Date { get; set; }
    }
```

<p> Figure 2.5 | Storing User inputs into the database </p>
<br/><br/>

# IF_PBKK-IUP-_MID_5025201159_M.Fachry-DwiHandoko
<br/><br/>
<h3> BMI Calculator App  :  .NET MAUI (C#) </h3>
<hr>

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

```
namespace BMICalculator
    public partial class MainPage : ContentPage
        private SQLiteAsyncConnection connection;
        public MainPage()
            InitializeComponent();
            InitializeDatabase();
```

<p> Figure 2.2 | Initializing / rendering the app </p>

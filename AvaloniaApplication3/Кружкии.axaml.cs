using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using AvaloniaApplication3;
using System;

namespace AvaloniaApplication3;

public partial class Кружкии : Window
{
    public Кружкии()
    {
        InitializeComponent();
        string fullTable = "SELECT Код, Название, Код_учителя, Кол_учеников, Время, Дни_недели FROM кружки;";
        ShowTable(fullTable);
    }
    private List<Mugs> mugs;
    private string connStr = "server=localhost;database=school;port=3306;User Id=root;password=Qwertyu1!ZZZ";
    private MySqlConnection conn;
    public void ShowTable(string sql)
    {
        mugs = new List<Mugs>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentMugs= new Mugs()
            {
                Код = reader.GetInt32("Код"),
                Название = reader.GetString("Название"),
                Код_учителя = reader.GetInt32("Код_учителя"),
                Кол_учеников = reader.GetInt32("Кол_учеников"),
                Время = reader.GetString("Время"),
                Дни_недели = reader.GetString("Дни_недели")
            };
            mugs.Add(currentMugs);
        }
        conn.Close();
        MugsGrid.ItemsSource = mugs;
    }
    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Form2 form2 = new AvaloniaApplication3.Form2();
        Close();
        form2.Show();
    }
}
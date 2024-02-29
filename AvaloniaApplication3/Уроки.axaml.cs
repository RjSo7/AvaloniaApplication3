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

public partial class Уроки : Window
{
    public Уроки()
    {
        InitializeComponent();
        string fullTable = "SELECT Код, Название, Код_учителя, Код_класса FROM урок;";
        ShowTable(fullTable);
    }
    private List<Lessons> lessons;
    private string connStr = "server=localhost;database=school;port=3306;User Id=root;password=Qwertyu1!ZZZ";
    private MySqlConnection conn;
    public void ShowTable(string sql)
    {
        lessons = new List<Lessons>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentLessons = new Lessons()
            {
                Код = reader.GetInt32("Код"),
                Название = reader.GetString("Название"),
                Код_учителя = reader.GetInt32("Код_учителя"),
                Код_класса = reader.GetInt32("Код_класса")
            };
            lessons.Add(currentLessons);
        }
        conn.Close();
        LessonsGrid.ItemsSource = lessons;
    }
    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Form2 form2 = new AvaloniaApplication3.Form2();
        Close();
        form2.Show();
    }
}
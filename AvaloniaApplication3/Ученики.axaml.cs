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

public partial class Ученики : Window
{
    public Ученики()
    {
        InitializeComponent();
        string fullTable = "SELECT Код, Фамилия, Имя, Отчество, Дата_рождения, Код_класса FROM ученик;";
        ShowTable(fullTable);
    }
    private List<Students> students;
    private string connStr = "server=localhost;database=school;port=3306;User Id=root;password=Qwertyu1!ZZZ";
    private MySqlConnection conn;
    public void ShowTable(string sql)
    {
        students = new List<Students>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentStudents = new Students()
            {
                Код = reader.GetInt32("Код"),
                Фамилия  = reader.GetString("Фамилия"),
                Имя = reader.GetString("Имя"),
                Отчество = reader.GetString("Отчество"),
                Дата_рождения = reader.GetString("Дата_рождения"),
                Код_класса = reader.GetInt32("Код_класса")
            };
            students.Add(currentStudents);
        }
        conn.Close();
        StudentsGrid.ItemsSource = students;
    }
    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Form2 form2 = new AvaloniaApplication3.Form2();
        Close();
        form2.Show();
    }
}
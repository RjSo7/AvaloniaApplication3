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

public partial class Расписание : Window
{
    public Расписание()
    {
        InitializeComponent();
        string fullTable = "SELECT Код, Код_урока, Понедельник, Вторник, Среда, Четверг, Пятница FROM недельное_расписание_уроков;";
        ShowTable(fullTable);
    }
    private List<Schedule> schedule;
    private string connStr = "server=localhost;database=school;port=3306;User Id=root;password=Qwertyu1!ZZZ";
    private MySqlConnection conn;
    public void ShowTable(string sql)
    {
        schedule = new List<Schedule>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentSchedule = new Schedule()
            {
                Код = reader.GetInt32("Код"),
                Код_урока = reader.GetInt32("Код_урока"),
                Понедельник = reader.GetString("Понедельник"),
                Вторник = reader.GetString("Вторник"),
                Среда = reader.GetString("Среда"),
                Четверг = reader.GetString("Четверг"),
                Пятница = reader.GetString("Пятница")
            };
            schedule.Add(currentSchedule);
        }
        conn.Close();
        ScheduleGrid.ItemsSource = schedule;
    }
    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Form2 form2 = new AvaloniaApplication3.Form2();
        Close();
        form2.Show();
    }
}
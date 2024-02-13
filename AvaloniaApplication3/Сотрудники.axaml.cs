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

public partial class Сотрудники : Window
{
    public Сотрудники()
    {
        InitializeComponent();
        string fullTable = "SELECT Код, Фамилия, Имя, Стаж_работы, Код_квалификация, Код_специализация FROM инструктор;";
        ShowTable(fullTable);
        FillCmb();
    }
    private List<Instructor> instructor;
    private string connStr = "server=localhost;database=complex;port=3306;User Id=root;password=Qwertyu1!ZZZ";
    private MySqlConnection conn;
    public void ShowTable(string sql)
    {
        instructor = new List<Instructor>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentInstructor = new Instructor()
            {
                Код = reader.GetInt32("Код"),
                Фамилия  = reader.GetString("Фамилия"),
                Имя = reader.GetString("Имя"),
                Стаж_работы = reader.GetString("Стаж_работы"),
                Код_квалификация = reader.GetInt32("Код_квалификация"),
                Код_специализация = reader.GetInt32("Код_специализация")
            };
            instructor.Add(currentInstructor);
        }
        conn.Close();
        InstructorGrid.ItemsSource = instructor;
    }
    
    public void FillCmb()
    {
        instructor = new List<Instructor>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand("SELECT Код, Фамилия, Имя, Стаж_работы, Код_квалификация, Код_специализация FROM инструктор", conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentInstructor = new Instructor()
            {
                Код = reader.GetInt32("Код"),
                Фамилия  = reader.GetString("Фамилия"),
                Имя = reader.GetString("Имя"),
                Стаж_работы = reader.GetString("Стаж_работы"),
                Код_квалификация = reader.GetInt32("Код_квалификация"),
                Код_специализация = reader.GetInt32("Код_специализация")
            };
            instructor.Add(currentInstructor);
        }
        conn.Close();
        var typecmb = this.Find<ComboBox>(name:"CmbNum");
        typecmb.ItemsSource = instructor;
    }

    private void TwoSearch_OnClick(object? sender, RoutedEventArgs e)
    {
        string twotxt = "SELECT Код, Фамилия, Имя, Стаж_работы, Код_квалификация, Код_специализация FROM инструктор WHERE Имя LIKE '%" + SearchName.Text + "%' AND Код_квалификация LIKE '%" + SearchDolID.Text + "%'";
        ShowTable(twotxt);
    }

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Form2 form2 = new AvaloniaApplication3.Form2();
        Close();
        form2.Show();
    }

    private void Reset_OnClick(object? sender, RoutedEventArgs e)
    {
        string reset = "SELECT Код, Фамилия, Имя, Стаж_работы, Код_квалификация, Код_специализация FROM инструктор;";
        ShowTable(reset);
        SearchName.Text = string.Empty;
        SearchDolID.Text = string.Empty;
    }

    private void CmbNum_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var TypeCmB = (ComboBox)sender;
        var currentInstructor = TypeCmB.SelectedItem as Instructor;
        var fltrinstructor = instructor
            .Where(x => x.Код == currentInstructor.Код)
            .ToList();
        InstructorGrid.ItemsSource = fltrinstructor;
    }
}
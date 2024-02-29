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

public partial class Учителя : Window
{
    public Учителя()
    {
        InitializeComponent();
        string fullTable = "SELECT Код, Фамилия, Имя, Отчество, Стаж_работы, Классное_руководство, Код_кабинет, Код_предмета FROM учителя;";
        ShowTable(fullTable);
        FillCmb();
    }
    private List<Teachers> teacher;
    private string connStr = "server=localhost;database=school;port=3306;User Id=root;password=Qwertyu1!ZZZ";
    private MySqlConnection conn;
    public void ShowTable(string sql)
    {
        teacher = new List<Teachers>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentTeacher = new Teachers()
            {
                Код = reader.GetInt32("Код"),
                Фамилия  = reader.GetString("Фамилия"),
                Имя = reader.GetString("Имя"),
                Отчество = reader.GetString("Отчество"),
                Стаж_работы = reader.GetInt32("Стаж_работы"),
                Классное_руководство = reader.GetString("Классное_руководство"),
                Код_кабинет = reader.GetInt32("Код_кабинет"),
                Код_предмета = reader.GetInt32("Код_предмета")
            };
            teacher.Add(currentTeacher);
        }
        conn.Close();
        TeachersGrid.ItemsSource = teacher;
    }
    
    public void FillCmb()
    {
        teacher = new List<Teachers>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand("SELECT Код, Фамилия, Имя, Отчество, Стаж_работы, Классное_руководство, Код_кабинет, Код_предмета FROM учителя", conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentTeacher = new Teachers()
            {
                Код = reader.GetInt32("Код"),
                Фамилия  = reader.GetString("Фамилия"),
                Имя = reader.GetString("Имя"),
                Отчество = reader.GetString("Отчество"),
                Стаж_работы = reader.GetInt32("Стаж_работы"),
                Классное_руководство = reader.GetString("Классное_руководство"),
                Код_кабинет = reader.GetInt32("Код_кабинет"),
                Код_предмета = reader.GetInt32("Код_предмета")
            };
            teacher.Add(currentTeacher);
        }
        conn.Close();
        var typecmb = this.Find<ComboBox>(name:"CmbNum");
        typecmb.ItemsSource = teacher;
    }

    private void TwoSearch_OnClick(object? sender, RoutedEventArgs e)
    {
        string twotxt = "SELECT Код, Фамилия, Имя, Отчество, Стаж_работы, Классное_руководство, Код_кабинет, Код_предмета FROM учителя WHERE Фамилия LIKE '%" + SearchFIO.Text + "%' AND Код_кабинет LIKE '%" + SearchKab.Text + "%'";
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
        string reset = "SELECT Код, Фамилия, Имя, Отчество, Стаж_работы, Классное_руководство, Код_кабинет, Код_предмета FROM учителя;";
        ShowTable(reset);
        SearchFIO.Text = string.Empty;
        SearchKab.Text = string.Empty;
    }

    private void CmbNum_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var TypeCmB = (ComboBox)sender;
        var currentflTrteacher = TypeCmB.SelectedItem as Teachers;
        var fltrteacher = teacher
            .Where(x => x.Код == currentflTrteacher.Код)
            .ToList();
        TeachersGrid.ItemsSource = fltrteacher;
    }

    private void DeleteData(object? sender, RoutedEventArgs e)
    {
        try
        {
            Teachers currentTeachers = TeachersGrid.SelectedItem as Teachers;
            if (currentTeachers == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM учителя WHERE Код = " + currentTeachers.Код;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            teacher.Remove(currentTeachers);
            ShowTable("SELECT Код, Фамилия, Имя, Отчество, Стаж_работы, Классное_руководство, Код_кабинет, Код_предмета FROM учителя;");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void AddData(object? sender, RoutedEventArgs e)
    {
        Teachers newTeachers = new Teachers();
        DobOb.AddUpd addWindow = new DobOb.AddUpd(newTeachers, teacher);
        addWindow.Show();
        this.Close();
    }

    private void EditData(object? sender, RoutedEventArgs e)
    {
        Teachers currentTeachers = TeachersGrid.SelectedItem as Teachers;
        if (currentTeachers == null)
        {
            return;
        }
        DobOb.AddUpd editWindow = new DobOb.AddUpd(currentTeachers, teacher);
        editWindow.Show();
        this.Close();
    }
}
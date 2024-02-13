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

public partial class Инструкторы : Window
{
    public Инструкторы()
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
        string twotxt = "SELECT Код, Фамилия, Имя, Стаж_работы, Код_квалификация, Код_специализация FROM инструктор WHERE Фамилия LIKE '%" + SearchFIO.Text + "%' AND Код_квалификация LIKE '%" + SearchPhone.Text + "%'";
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
        SearchFIO.Text = string.Empty;
        SearchPhone.Text = string.Empty;
    }

    private void CmbNum_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var TypeCmB = (ComboBox)sender;
        var currentInstructor = TypeCmB.SelectedItem as Instructor;
        var fltrinstructort = instructor
            .Where(x => x.Код == currentInstructor.Код)
            .ToList();
        InstructorGrid.ItemsSource = fltrinstructort;
    }

    private void DeleteData(object? sender, RoutedEventArgs e)
    {
        try
        {
            Instructor currentInstructor = InstructorGrid.SelectedItem as Instructor;
            if (currentInstructor == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM инструктор WHERE Код = " + currentInstructor.Код;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            instructor.Remove(currentInstructor);
            ShowTable("SELECT Код, Фамилия, Имя, Стаж_работы, Код_квалификация, Код_специализация FROM инструктор;");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void AddData(object? sender, RoutedEventArgs e)
    {
        Instructor newInstructor = new Instructor();
        DobOb.AddUpd addWindow = new DobOb.AddUpd(newInstructor, instructor);
        addWindow.Show();
        this.Close();
    }

    private void EditData(object? sender, RoutedEventArgs e)
    {
        Instructor currentInstructor = InstructorGrid.SelectedItem as Instructor;
        if (currentInstructor == null)
        {
            return;
        }
        DobOb.AddUpd editWindow = new DobOb.AddUpd(currentInstructor, instructor);
        editWindow.Show();
        this.Close();
    }
}
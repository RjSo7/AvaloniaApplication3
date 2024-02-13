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

namespace DobOb;

public partial class AddUpd : Window
{
    private List<Instructor> Instructorr;
    private Instructor CurrentInstructor;
    public AddUpd( Instructor currentInstructor, List<Instructor> instructorr)
    {
        InitializeComponent();
        CurrentInstructor = currentInstructor;
        this.DataContext = CurrentInstructor;
        Instructorr = instructorr;
    }
    private MySqlConnection conn;
    private string connStr = "server=localhost;database=complex;port=3306;User Id=root;password=Qwertyu1!ZZZ";
    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var instructorr = Instructorr.FirstOrDefault(x => x.Код == CurrentInstructor.Код);
        if (instructorr == null)
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string add = "INSERT INTO инструктор (Код, Фамилия, Имя, Стаж_работы, Код_квалификация, Код_специализация) VALUES (" + Convert.ToInt32(Kod.Text) + ", '" + Familia.Text + "', '" + Name.Text + "', '" + Staj.Text + "', '" + Convert.ToInt32(Kval.Text) + "', " + Convert.ToInt32(Cpez.Text) + ");";
                MySqlCommand cmd = new MySqlCommand(add, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error" + exception);
            }
        }
        else
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string upd = "UPDATE инструктор SET Фамилия = '" +Familia.Text + "', Имя = '" + Name.Text + "', Стаж_работы = '" + Staj.Text + "', Код_квалификация = '" + Convert.ToInt32(Kval.Text)  + "', Код_специализация = " + Convert.ToInt32(Cpez.Text) + " WHERE Код = " + Convert.ToInt32(Kod.Text) + ";";
                MySqlCommand cmd = new MySqlCommand(upd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Console.Write("Error" + exception);
            }
        }
    }

    private void GoBack(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Инструкторы instructorr = new AvaloniaApplication3.Инструкторы();
        this.Close();
        instructorr.Show(); 
    }
}
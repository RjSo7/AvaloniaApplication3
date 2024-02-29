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
    private List<Teachers> Teacherr;
    private Teachers _currentTeachers;
    public AddUpd( Teachers currentTeachers, List<Teachers> teacherr)
    {
        InitializeComponent();
        _currentTeachers = currentTeachers;
        this.DataContext = _currentTeachers;
        Teacherr = teacherr;
    }
    private MySqlConnection conn;
    private string connStr = "server=localhost;database=school;port=3306;User Id=root;password=Qwertyu1!ZZZ";
    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var teacherr = Teacherr.FirstOrDefault(x => x.Код == _currentTeachers.Код);
        if (teacherr == null)
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string add = "INSERT INTO учителя VALUES (" + Convert.ToInt32(Kod.Text)+ ", '" + Familia.Text + "', '" + Name.Text + "', '" + Otchestvo.Text + "', " + Convert.ToInt32(Staj.Text ) + ", '"+ Klass.Text + "', " + Convert.ToInt32(Kab.Text ) + ", " + Convert.ToInt32(Pred.Text )+");";
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
                string upd = "UPDATE учителя SET Фамилия = '" + Familia.Text + "', Имя = '" + Name.Text + "', Отчество = '" + Otchestvo.Text + "',Стаж_работы = "+ Convert.ToInt32(Staj.Text) + ", Классное_руководство = '" + Klass.Text + "', Код_кабинет = "+ Convert.ToInt32(Kab.Text) + ", Код_предмета = "+ Convert.ToInt32(Pred.Text)+ " WHERE Код = " + Convert.ToInt32(Kod.Text) + ";";
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
        AvaloniaApplication3.Учителя teacherr = new AvaloniaApplication3.Учителя();
        this.Close();
        teacherr.Show(); 
    }
}
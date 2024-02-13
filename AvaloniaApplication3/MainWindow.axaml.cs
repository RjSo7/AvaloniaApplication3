using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication3;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void Authorization(object? sender, RoutedEventArgs e)
    {
        if (Login.Text == "Admin" && Password.Text == "12345678")
        {
            var form2 = new AvaloniaApplication3.Form2();
            Hide();
            form2.Show(); 
        }
        else
        {
            Console.Write("Неверный логин или пароль");
        }
    }
    
    public void Exit_PR(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
}
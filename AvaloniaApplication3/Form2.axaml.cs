using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;


namespace AvaloniaApplication3;

public partial class Form2 : Window
{
    public Form2()
    {
        InitializeComponent();
    }
    public void Instructors(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Инструкторы instructor = new AvaloniaApplication3.Инструкторы();
        Close();
        instructor.Show(); 
    }
    private void Exit_OnClick(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
}
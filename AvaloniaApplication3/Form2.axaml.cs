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
    public void Teachers(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Учителя teacher = new AvaloniaApplication3.Учителя();
        Close();
        teacher.Show(); 
    }
    public void Students(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Ученики students = new AvaloniaApplication3.Ученики();
        Close();
        students.Show(); 
    }
    public void Mugs(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Кружкии mugs = new AvaloniaApplication3.Кружкии();
        Close();
        mugs.Show(); 
    }
    public void Lessons(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Уроки lessons = new AvaloniaApplication3.Уроки();
        Close();
        lessons.Show(); 
    }
    public void Schedule(object? sender, RoutedEventArgs e)
    {
        AvaloniaApplication3.Расписание schedule = new AvaloniaApplication3.Расписание();
        Close();
        schedule.Show(); 
    }
    private void Exit_OnClick(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
}
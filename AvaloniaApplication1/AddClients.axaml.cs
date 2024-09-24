using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;

namespace AvaloniaApplication1;

public partial class AddClients : Window
{
    public AddClients()
    {
        InitializeComponent();
        Save.Click += Save_Click;
    }

    private void Save_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int id = 1;
        
             
        if(Contan.list.Count > 0)
        {
            id = Contan.list.OrderBy(x => x.Id).LastOrDefault().Id + 1;
        }
      


       
        Clients clients = new Clients()
        {
            Id = id,
            Gender = 'ì',
            Name = Name.Text,
            Lastname = Lastname.Text,
            PhoneNumber = PhoneNumber.Text,
            Email = Email.Text,
            RegistrationDate = new System.DateOnly(2000, 05, 05)

        };

        Contan.list.Add(clients);

        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    public AddClients(Clients clients)
    {
        InitializeComponent();
        DataContext = clients;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

   
}
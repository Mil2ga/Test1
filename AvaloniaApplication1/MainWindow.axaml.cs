using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        


        public MainWindow()
        {
            InitializeComponent();
            FillingList();
         

        }
        public void FillingList()
        {
            
            
            int StartSort = Contan.list.Count;

            if (Search.Text != null) 
            {
                Contan.list = Contan.list.Where(x => x.Name.Contains(Search.Text)).ToList();
            }
            switch (Filter.SelectedIndex)
            {
                case 0:
                    Contan.list = Contan.list; break;
                case 1:
                    Contan.list = Contan.list.Where(x => x.Gender == 'м').ToList(); break;      
                case 2:
                    Contan.list = Contan.list.Where(x => x.Gender == 'ж').ToList(); break;
            }
            switch (Sort.SelectedIndex)
            {
                case 0:
                    Contan.list = Contan.list; break;
                case 1:
                    Contan.list = Contan.list.OrderBy(x => x.Lastname).ToList(); break;
            }
            Elements.Text = Contan.list.Count.ToString()+" из " + StartSort;

            PeopleList.ItemsSource = new ObservableCollection<Clients>(Contan.list);
        }

        private void TextBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            FillingList();
        }

        private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            FillingList();

        }

        private void ComboBox_SelectionChanged_1(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            FillingList();
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            int idclient = (int)(sender as Button).Tag;
            Contan.list.Remove(Contan.list.FirstOrDefault(x=>x.Id == idclient));
            PeopleList.ItemsSource = new ObservableCollection<Clients>(Contan.list);
        }

        private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            int idclient = (int)(sender as Button).Tag;

            var client = Contan.list.FirstOrDefault(x => x.Id == idclient);
            AddClients addClients = new AddClients(client);
            addClients.Show();
            Close();
        }

        private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            AddClients addClients = new AddClients();
            addClients.Show();
            Close();
        }
    }
}
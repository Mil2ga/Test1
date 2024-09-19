using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        List<Clients> list = new List<Clients>();


        public MainWindow()
        {
            InitializeComponent();
            FillingList();
            list.Add(new Clients()
            {
                Id = 1,
                Gender = 'ж',
                Name = "Дарья",
                Lastname = "Иост",
                PhoneNumber = "+7 (952) 456-24-34",
                Email = "Rhdu23@gmail.com",
                RegistrationDate = new System.DateOnly(2001, 12, 30)
            }

            );
            list.Add(new Clients()
            {
                Id = 2,
                Gender = 'ж',
                Name = "Дарья",
                Lastname = "Павлова",
                PhoneNumber = "+7 (952) 756-84-36",
                Email = "vkodty@gmail.com",
                RegistrationDate = new System.DateOnly(2011, 10, 20)
            }

            );
            list.Add(new Clients()
            {
                Id = 3,
                Gender = 'м',
                Name = "Дмитрий",
                Lastname = "Моховиков",
                PhoneNumber = "+7 (911) 676-92-12",
                Email = "Rfdhjs453@gmail.com",
                RegistrationDate = new System.DateOnly(2021, 03, 05)
            }

            );

        }
        public void FillingList()
        {
            
            
            int StartSort = list.Count;

            if (Search.Text != null) 
            {
                list = list.Where(x => x.Name.Contains(Search.Text)).ToList();
            }
            switch (Filter.SelectedIndex)
            {
                case 0:
                    list = list; break;
                case 1:
                    list = list.Where(x => x.Gender == 'м').ToList(); break;      
                case 2:
                    list = list.Where(x => x.Gender == 'ж').ToList(); break;
            }
            switch (Sort.SelectedIndex)
            {
                case 0:
                    list = list; break;
                case 1:
                    list = list.OrderBy(x => x.Lastname).ToList(); break;
            }
            Elements.Text = list.Count.ToString()+" из " + StartSort;

            PeopleList.ItemsSource = list;
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
            list.Remove(list.FirstOrDefault(x=>x.Id == idclient));
            PeopleList.ItemsSource = new ObservableCollection<Clients>(list);
        }
    }
}
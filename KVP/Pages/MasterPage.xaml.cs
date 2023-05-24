using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using KVP.Entites;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KVP.Pages
{
    /// <summary>
    /// Логика взаимодействия для MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Window
    {
        public MasterPage()
        {
            InitializeComponent();

        }
        private void FilmList_Loaded(object sender, RoutedEventArgs e)
        {
            FilmList.ItemsSource = App.Context.Film.ToList();
        }
        private void ZakupkaList_Loaded(object sender, RoutedEventArgs e)
        {
            ZakupkaList.ItemsSource = App.Context.Purchase.ToList();
        }
        private void CinemaList_Loaded(object sender, RoutedEventArgs e)
        {
            CinemaList.ItemsSource = App.Context.Cinema.ToList();
        }
        private void ArendaFilmList_Loaded(object sender, RoutedEventArgs e)
        {
            ArendaFilmList.ItemsSource = App.Context.Rent.ToList();
        }
       
        //Таблица фильмы
        private void ButDelClickFilm(object sender, RoutedEventArgs e)
        { 
            {
                if (MessageBox.Show("Вы действительно хотите удалить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var SelectedFilm = FilmList.SelectedItem as Film;
                    App.Context.Film.Remove(SelectedFilm);
                    SaveToBd();
                    MessageBox.Show("Строка удалена");
                    FilmList.ItemsSource = App.Context.Film.ToList();
                }
            }
        }
        private static void SaveToBd()
        {
            try
            {
                App.Context.SaveChanges();
                MessageBox.Show("Сохранние успешно");
            }
            catch (Exception)
            {
                MessageBox.Show("Допущенна фатальная ошибка, операция прервана");
            }
        }
        private void ButAddClickFilm(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите добавить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var SelectedFilm = FilmList.SelectedItem as Film;
                    App.Context.Film.Add(SelectedFilm);
                    SaveToBd();
                    FilmList.ItemsSource = App.Context.Film.ToList();
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Добавление пустого значения запрещено");
                }
            }
        }
        private void ButUpdClickFilm(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите отредактирование строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var SelectedFilm = FilmList.SelectedItem as Film;
                SaveToBd();
                FilmList.ItemsSource = App.Context.Film.ToList();
            }

        }
        //Таблица закупки
        private void ButDelClickZakupka(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var SelectedZakupka = ZakupkaList.SelectedItem as Purchase;
                App.Context.Purchase.Remove(SelectedZakupka);
                SaveToBd();
                ZakupkaList.ItemsSource = App.Context.Purchase.ToList();
            }
        }
        private void ButUpdClickZakupka(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите отредактировать строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var SelectedZakupka = ZakupkaList.SelectedItem as Purchase;
                SaveToBd();
                ZakupkaList.ItemsSource = App.Context.Purchase.ToList();
            }
        }
        private void ButAddClickZakupka(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите добавить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var SelectedZakupka = ZakupkaList.SelectedItem as Purchase;
                    App.Context.Purchase.Add(SelectedZakupka);
                    SaveToBd();
                    ZakupkaList.ItemsSource = App.Context.Purchase.ToList();
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Добавление пустого значения запрещено");
                }
            }
        }
        // Таблица Аренда
        private void ButDelClickArenda(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var SelectedArend = ArendaFilmList.SelectedItem as Rent;
                App.Context.Rent.Remove(SelectedArend);
                SaveToBd();
                ArendaFilmList.ItemsSource = App.Context.Rent.ToList();
            }
        }
        private void ButAddClickArenda(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var SelectedArend = ArendaFilmList.SelectedItem as Rent;
                    App.Context.Rent.Add(SelectedArend);
                    SaveToBd();
                    ArendaFilmList.ItemsSource = App.Context.Rent.ToList();
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Добавление пустого значения запрещено");
                }
            }
        }
        private void ButUpdClickArenda(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var SelectedArend = ArendaFilmList.SelectedItem as Rent;
                SaveToBd();
                ArendaFilmList.ItemsSource = App.Context.Rent.ToList();
            }
        }
        // Таблица кинотеатры 
        private void ButDelClickCinema(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var SelectedCinema = CinemaList.SelectedItem as Cinema;
                App.Context.Cinema.Remove(SelectedCinema);
                SaveToBd();
                CinemaList.ItemsSource = App.Context.Cinema.ToList();
            }
        }
        private void ButAddClickCinema(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var SelectedCinema = CinemaList.SelectedItem as Cinema;
                    App.Context.Cinema.Add(SelectedCinema);
                    SaveToBd();
                    CinemaList.ItemsSource = App.Context.Cinema.ToList();
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Добавление пустого значения запрещено");
                }
            }
        }
        private void ButUpdClickCinema(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить строку?", "Уведомлениe", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var SelectedCinema = CinemaList.SelectedItem as Cinema;
                SaveToBd();
                CinemaList.ItemsSource = App.Context.Cinema.ToList();
            }
        }

        private void ZakupkaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ButClkArenda(object sender, RoutedEventArgs e)
        {

        }
        private void ButClkDolgi(object sender, RoutedEventArgs e)
        {

        }
        private void ButClkReiting(object sender, RoutedEventArgs e)
        {

        }
        private void ButClkViruchka(object sender, RoutedEventArgs e)
        {

        }
    }
}

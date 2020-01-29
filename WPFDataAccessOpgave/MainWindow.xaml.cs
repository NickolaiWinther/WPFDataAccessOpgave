using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDataAccessOpgave.Dal;
using WPFDataAccessOpgave.Entities;

namespace WPFDataAccessOpgave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Film SelectedFilm { get; set; }
        public List<Film> AllFilms { get; set; } = new List<Film>();
        private FilmRepository FilmRepository { get; set; } = new FilmRepository();
        public MainWindow()
        {
            InitializeComponent();
            GetAllFilms();
            DataContext = this;

            
            FilmListBox.ItemsSource = AllFilms;

        }

        private void GetAllFilms()
        {
            AllFilms = FilmRepository.GetAllFilms().OrderBy(f => f.Titel).ToList();
        }

        private void FilmListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedFilm = (Film)FilmListBox.SelectedItem;

            FilmTitelTextBox.Text =  SelectedFilm.Titel;
            FilmLandTextBox.Text =   SelectedFilm.Land;
            FilmYearTextBox.Text =   SelectedFilm.Year.ToString();
            FilmGenreTextBox.Text =  SelectedFilm.Genre;
            FilmOscarsTextBox.Text = SelectedFilm.Oscars.ToString();

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilmListBox.ItemsSource = AllFilms.Where(f => f.Titel.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
        }

        private void CreateFilmButton_Click(object sender, RoutedEventArgs e)
        {
            CreateFilmWindow createFilmWindow = new CreateFilmWindow();
            createFilmWindow.Show();
        }
    }
}

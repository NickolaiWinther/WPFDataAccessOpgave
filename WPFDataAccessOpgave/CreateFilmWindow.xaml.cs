using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WPFDataAccessOpgave.Dal;
using WPFDataAccessOpgave.Entities;

namespace WPFDataAccessOpgave
{
    /// <summary>
    /// Interaction logic for CreateFilmWindow.xaml
    /// </summary>
    public partial class CreateFilmWindow : Window
    {
        public Film NewFilm { get; set; } = new Film();
        FilmRepository FilmRepository { get; set; } = new FilmRepository();
        public CreateFilmWindow()
        {
            InitializeComponent();
            DataContext = this;
            //ClearTextBoxes();
        }

        private void CreateFilmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FilmRepository.Insert(NewFilm);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            NewFilm = new Film();
        }

        //private void ClearTextBoxes()
        //{
        //    FilmTitelTextBox.Text = "";
        //    FilmLandTextBox.Text = "";
        //    FilmYearTextBox.Text = "";
        //    FilmGenreTextBox.Text = "";
        //    FilmOscarsTextBox.Text = "";
        //}
    }
}

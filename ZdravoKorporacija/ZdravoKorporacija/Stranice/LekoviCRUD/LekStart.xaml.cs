using Repository;
using Service;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Stranice.UpravnikCRUD;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System;
using ZdravoKorporacija.DTO;
using Model;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for LekStart.xaml
    /// </summary>
    public partial class LekStart : Page
    {
        public ChartValues<int> Vrednost { get; set; }
        LekServis lekServis = new LekServis();
        public LekStart()
        {
            InitializeComponent();
            // dgLekovi.ItemsSource = new ObservableCollection<Lek>(lekServis.PregledSvihLekova());
            lekServis.PregledSvihLekova();
            dgLekovi.ItemsSource = LekRepozitorijum.Instance.lekovi;

            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);

            chart1.Series = new SeriesCollection { };

            foreach (Lek lek in lekServis.PregledSvihLekova())
            {
                PieSeries pieSeria = new PieSeries
                {
                    Title = lek.NazivLeka,
                    Values = new ChartValues<double> { lek.Kolicina },
                    DataLabels = true,
                    LabelPoint = labelPoint
                };
                chart1.Series.Add(pieSeria);
            }



        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            DodavanjeZahtevaZaLek dodavanjeZahtevaZaLek = new DodavanjeZahtevaZaLek();
            dodavanjeZahtevaZaLek.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new IzvestajLekovi();
        }

        private void dgLekovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pregledNeodobrenihLekova_Click(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new NeodobreniZahteviZaLek();
            //this.PieChart();
        }

        public Func<ChartPoint, string> Naziv { get; set; }
        public void PieChart()
        {
            Naziv = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }

        private void chart1_DataClick(object sender, ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartPoint.SeriesView;
            selectedSeries.PushOut = 8;
        }


    }
}

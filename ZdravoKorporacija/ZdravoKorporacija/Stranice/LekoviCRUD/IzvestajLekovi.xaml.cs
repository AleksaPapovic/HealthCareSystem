using LiveCharts;
using LiveCharts.Wpf;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using Service;
using System.Linq;
using Controller;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for IzvestajLekovi.xaml
    /// </summary>
    public partial class IzvestajLekovi : Page
    {
        LekController lekController = new LekController();
        IzvestajLekoviController izvestajLekoviController = new IzvestajLekoviController();
        public List<LekDTO> sortiraniLekovi;
        public IzvestajLekovi()
        {
            InitializeComponent();
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);

            chart1.Series = new SeriesCollection { };

            foreach (LekDTO lek in lekController.PregledSvihLekova())
            {
                PieSeries pieSeria = new PieSeries
                {
                    Title = lek.NazivLeka,
                    Values = new ChartValues<double> { Double.Parse(lek.Kolicina) },
                    DataLabels = true,
                    LabelPoint = labelPoint
                };
                chart1.Series.Add(pieSeria);
            }


            int i = 0;
            sortiraniLekovi =
            lekController.PregledSvihLekova().OrderByDescending(order => order.Kolicina).ToList();
            TopLek1.Content = "1. " + sortiraniLekovi[0].NazivLeka + "  sa kolicinom " + sortiraniLekovi[0].Kolicina;
            TopLek2.Content = "2. " + sortiraniLekovi[1].NazivLeka + "  sa kolicinom " + sortiraniLekovi[1].Kolicina;
            TopLek3.Content = "3. " + sortiraniLekovi[2].NazivLeka + "  sa kolicinom " + sortiraniLekovi[2].Kolicina;

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

        private void sacuvajPDF_Click(object sender, RoutedEventArgs e)
        {
            izvestajLekoviController.generisiIzvestajPDF(this, sortiraniLekovi);
        }

        private void sacuvajXML_Click(object sender, RoutedEventArgs e)
        {
            izvestajLekoviController.generisiIzvestajXML(this, sortiraniLekovi);
        }

        private void sacuvajCSV_Click(object sender, RoutedEventArgs e)
        {
            izvestajLekoviController.generisiIzvestajCSV(this, sortiraniLekovi);
        }
    }
}

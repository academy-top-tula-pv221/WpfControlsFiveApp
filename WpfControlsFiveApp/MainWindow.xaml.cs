using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfControlsFiveApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        
        BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgresChanged;

            List<DateTime> dates = new List<DateTime>();

            CalendarDateRange range1 = new CalendarDateRange();
            range1.Start = new DateTime(2023, 4, 2);
            range1.End = new DateTime(2023, 4, 9);

            CalendarDateRange range2 = new CalendarDateRange();
            range2.Start = new DateTime(2023, 4, 17);
            range2.End = new DateTime(2023, 4, 23);

            calendar.BlackoutDates.Add(range1);
            calendar.BlackoutDates.Add(range2);

            picker.BlackoutDates.Add(range1);
            picker.BlackoutDates.Add(range2);


        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int fileCount = 10;
            for (int i = 0; i <= fileCount; i++)
            {
                if(sender is BackgroundWorker worker)
                {
                    worker.ReportProgress(i * 100/fileCount);
                    Thread.Sleep(100);
                }
            }
        }

        void worker_ProgresChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = (double)e.NewValue;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Maximum = 100;

            progressBar.Value = 0;
            worker.RunWorkerAsync();
            
        }
    }
}

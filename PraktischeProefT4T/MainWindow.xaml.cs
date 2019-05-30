using Autofac;
using PraktischeProefT4T.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PraktischeProefT4T
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPlanner planner;
        public MainWindow()
        {
            var container = ContainerConfig.Configure();
            using (var scope =container.BeginLifetimeScope())
            {
                InitializeComponent();

                var morningTrack = new Track(3 * 60);
                var afternoonTrack = new Track(4 * 60, 3 * 60);
                
                 planner = container.Resolve<IPlanner>(new NamedParameter("initMorningTrack", morningTrack), new NamedParameter("initAfternoonTrack", afternoonTrack));


               
               
            }
          

        }
       
        private List<string> RecordsToStrings(List<Talk> talks)
        {
            List<string> recordsStrings = new List<string>();
            foreach (Talk talk in talks)
            {
                TimeSpan result = TimeSpan.FromMinutes(talk.StartTime);
                string recordsToStrings;
                string TimeString = result.ToString("hh':'mm");
                if (talk.Duration == 5)
                {
                    recordsToStrings = $"{TimeString}{talk.TimePrefix} {talk.Title} lightning  ";

                }else if(talk.Duration == 0){
                    recordsToStrings = $"{TimeString}{talk.TimePrefix} {talk.Title}";
                }
                else
                {
                    recordsToStrings = $"{TimeString}{talk.TimePrefix} {talk.Title} {talk.Duration}min";

                }
                recordsStrings.Add(recordsToStrings);

            }
            return recordsStrings;




        }
        private List<string> RecordsToStrings(List<Talk> talks, bool showTime)
        {
            List<string> recordsStrings = new List<string>();
           
            foreach (Talk talk in talks)
            {
                string timeString;
                string recordsToStrings;
                if (showTime)
                {
                    TimeSpan result = TimeSpan.FromMinutes(talk.StartTime);
                    
                     timeString = result.ToString("hh':'mm");
                }
                else
                {
                    timeString = "";
                }
               
                if (talk.Duration == 5)
                {
                    recordsToStrings = $"{timeString}{talk.TimePrefix} {talk.Title} lightning  ";

                }
                else if (talk.Duration == 0)
                {
                    recordsToStrings = $"{timeString}{talk.TimePrefix} {talk.Title}";
                }
                else
                {
                    recordsToStrings = $"{timeString}{talk.TimePrefix} {talk.Title} {talk.Duration}min";

                }
                recordsStrings.Add(recordsToStrings);

            }
            return recordsStrings;




        }
        private void SubmitRecord_Click(object sender, RoutedEventArgs e)
        {
            planner.AddUserRecord(inputRecord.Text);
            inputRecord.Clear();
            allTalks.ItemsSource = RecordsToStrings(planner.AllTalks, false);
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            planner.ImportFromFile();
            allTalks.ItemsSource = RecordsToStrings(planner.AllTalks, false);
        }

        private void makePlanning_Click(object sender, RoutedEventArgs e)
        {
            planner.MaakPlanning();
            track1.ItemsSource = RecordsToStrings(planner.Track1);
            track2.ItemsSource = RecordsToStrings(planner.Track2);
        }
    }
}

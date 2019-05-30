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
         
        public MainWindow()
        {
            var container = ContainerConfig.Configure();
            using (var scope =container.BeginLifetimeScope())
            {
                InitializeComponent();

                var morningTrack = new Track(3 * 60);
                var afternoonTrack = new Track(4 * 60, 3 * 60);
                var dataLoader = scope.Resolve<IDataLoader>(new NamedParameter("initDbPath", @"\..\..\Data\EventData.txt"));
                var planner = scope.Resolve<IPlanner>(new NamedParameter("initDatLoader", dataLoader), new NamedParameter("initMorningTrack", morningTrack), new NamedParameter("initAfternoonTrack", afternoonTrack));

                allTalks.ItemsSource = RecordsToStrings(dataLoader.Records);
                track1.ItemsSource = RecordsToStrings(planner.Track1);
                track2.ItemsSource = RecordsToStrings(planner.Track2);
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

        private void SubmitRecord_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

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
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace PraktischeProefT4T
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPlanner planner;

        IPresentationFormatter presentationFormatter;
        IInputValidator inputValidator;


        public List<string> TrackData1 { get => presentationFormatter.RecordsToStrings(planner.Track1); }
        public List<string> TrackData2 { get => presentationFormatter.RecordsToStrings(planner.Track2); }

        public MainWindow()
        {

            var container = ContainerConfig.Configure();


            Track morningTrack = new Track(3 * 60);
            Track afternoonTrack = new Track(4 * 60, 3 * 60);
            planner = container.Resolve<IPlanner>
       (new NamedParameter("initMorningTrack", morningTrack),
       new NamedParameter("initAfternoonTrack", afternoonTrack));

            presentationFormatter = container.Resolve<IPresentationFormatter>();
            inputValidator = container.Resolve<IInputValidator>();



        }

        
        private void SubmitRecord_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int duration;
                string title;
                if (inputValidator.ValidateTalk(inputTitle.Text, inputDuration.Text, out title, out duration))
                {
                    planner.AddUserRecord(title, duration);
                    inputTitle.Clear();
                    inputDuration.Clear();
                }

                allTalks.ItemsSource = presentationFormatter.RecordsToStrings(planner.AllTalks, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);



            }



        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                planner.ImportFromFile();
                allTalks.ItemsSource = presentationFormatter.RecordsToStrings(planner.AllTalks, false);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void makePlanning_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (planner.AllTalks.Count > 0)
                {
                    if (planner.MaakPlanning(planner.AllTalks))
                    {
                        track1.ItemsSource = TrackData1;
                        track2.ItemsSource = TrackData2;
                    }
                    else
                    {
                        throw new Exception("Unable to Schedule loaded data");
                    }
                }
                else
                {
                    throw new Exception("No data loaded");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }






        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

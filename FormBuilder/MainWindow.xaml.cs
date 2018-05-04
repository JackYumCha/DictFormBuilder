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
using System.Web;

namespace FormBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string test = @"AJAXREQUEST=_viewRoot&bookingDeliveryDetails=bookingDeliveryDetails&bookingDeliveryDetails%3AenableUnsavedChangesWarning=false&bookingDeliveryDetails%3AunsavedChangesWarningHashCode=&bookingDeliveryDetails%3AunsavedChanges=false&bookingDeliveryDetails%3AdetailCount=5&bookingDeliveryDetails%3AdefaultDeliveryPeriodFrom=&bookingDeliveryDetails%3AstateSelect=NSW&bookingDeliveryDetails%3AdeliveryPeriodFromInput=16%2F04%2F2018&bookingDeliveryDetails%3AdeliveryPeriodToInput=20%2F04%2F2018&bookingDeliveryDetails%3ArequiredLodgmentDateInput=05%2F04%2F2018&bookingDeliveryDetails%3AboundaryTypeSelect=6&bookingDeliveryDetails%3AareaSelect=&bookingDeliveryDetails%3Aj_id68_selection=&bookingDeliveryDetails%3AsearchResultsTable%3AstreetColumnCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3AroadsideColumnCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3ApoboxColumnCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3AcounterColumnCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A0%3AstreetCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A0%3AroadsideCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A0%3AcounterCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A1%3AstreetCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A1%3AroadsideCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A1%3AcounterCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A2%3AstreetCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A2%3AroadsideCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A2%3AcounterCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A3%3AstreetCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A3%3AroadsideCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A3%3AcounterCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A4%3AstreetCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A4%3AroadsideCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A4%3ApoboxCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3A4%3AcounterCountCheckbox=on&bookingDeliveryDetails%3AsearchResultsTable%3As=-1&bookingDeliveryDetails%3AdeliverNoMoreThanInput=&javax.faces.ViewState=e15s19&boundaryId=3620&bookingAreaOid=24927713&mapName=DeliveryBoundaryDetailsCustomMap&bookingDeliveryDetails%3AsearchResultsTable%3A1%3AdeliveryBoundaryDetailsMapLink=bookingDeliveryDetails%3AsearchResultsTable%3A1%3AdeliveryBoundaryDetailsMapLink&";

        public void ViewDict(object sender, RoutedEventArgs e)
        {
            string formdata = tbInput.Text;

            try
            {
                tbOutput.Text =
                    string.Join("\n", formdata
                   .Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(
                       entry => $@"{{{string.Join(", ", entry
                            .Split(new char[] { '=' })
                            .Select(value => $"\"{HttpUtility.UrlDecode(value)}\""))}}}"
                           )
                   .Select(line => $"{line},"));
            }
            catch(Exception ex) { }
        }
    }
}

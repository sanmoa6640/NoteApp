using NoteApp.Services;
using NoteApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {

        public HomeView(HomeViewModel homeViewModel)
        {
            InitializeComponent();

            #region microblink
            //var microblinkFactory = DependencyService.Get<IMicroblinkScannerFactory>();
            //string licenseKey;
            //if (Device.RuntimePlatform == Device.iOS)
            //{
            //    licenseKey = "sRwAAAEVY29tLm1pY3JvYmxpbmsuc2FtcGxl1BIcP+dpSuS/38JVP6aKNaBKXyOa0lx8FMppKnmLvzN4FxHDuhb/iU7ojs9ZV2HHMGkgO+lMeHXvwTM9jNX3cTyExpXVaxJ06Ki8O5II97dgREuRvs8ZoV7qGSMhZtLe9b4wPe69vbvgkmGrUPLzNGJX8uxTtpRgLOtFSpNXshQZ/nnRhxi/F2d9sY7sYI1jTYAMoacu0AWrciTcSFTYe57lLkTFH6wtJTmGzzPF18NqhltfO7+5Bwk5/9AQ9blIOOBFr5s=";
            //}
            //else
            //{
            //    licenseKey = "sRwAAAAVY29tLm1pY3JvYmxpbmsuc2FtcGxlU9kJdf5ZkGlTu9U3P8tqz/OQlP4WPMiRjJ8ogPx3I/XahwQ+FZH+4q0sbbRGfo1IDXwYR6Cdy7o6IZeOzT2iRIZT7eW+Cqk65y1ngxGxk5caaR7WSyCGCe/yQqSjp1fxerQaVWUL0uK7s0xfv8EtVTqz7hocOKoqeC4c2m0L+WeEc7kAHGuYjoIMVm2BOmEtCOR4grLQUmrz5ojA8fFjuknxBnEGkFWdJNT0evkrH/BgcnM9S+CH2018twWbYYV8ggqaD8DB";
            //}
            //blinkID = microblinkFactory.CreateMicroblinkScanner(licenseKey);
            //MessagingCenter.Subscribe<Messages.ScanningDoneMessage>(this, Messages.ScanningDoneMessageId, (sender) =>
            //{
            //    ImageSource faceImageSource = null;
            //    ImageSource fullDocumentFrontImageSource = null;
            //    ImageSource fullDocumentBackImageSource = null;
            //    ImageSource successFrameImageSource = null;

            //    string stringResult = "No valid results.";

            //    // if user cancelled scanning, sender.ScanningCancelled will be true
            //    if (sender.ScanningCancelled)
            //    {
            //        stringResult = "Scanning cancelled";
            //    }
            //    else
            //    {
            //        // otherwise, one or more recognizers used in RecognizerCollection (see StartScan method below)
            //        // will contain result

            //        // if specific recognizer's result's state is Valid, then it contains data recognized from image
            //        if (blinkidRecognizer.Result.ResultState == RecognizerResultState.Valid)
            //        {
            //            var blinkidResult = blinkidRecognizer.Result;
            //            stringResult =
            //                "BlinkID recognizer result:\n" +
            //                BuildResult(blinkidResult.FirstName, "First name") +
            //                BuildResult(blinkidResult.LastName, "Last name") +
            //                BuildResult(blinkidResult.FullName, "Full name") +
            //                BuildResult(blinkidResult.LocalizedName, "Localized name") +
            //                BuildResult(blinkidResult.AdditionalNameInformation, "Additional name info") +
            //                BuildResult(blinkidResult.Address, "Address") +
            //                BuildResult(blinkidResult.AdditionalAddressInformation, "Additional address info") +
            //                BuildResult(blinkidResult.DocumentNumber, "Document number") +
            //                BuildResult(blinkidResult.DocumentAdditionalNumber, "Additional document number") +
            //                BuildResult(blinkidResult.Sex, "Sex") +
            //                BuildResult(blinkidResult.IssuingAuthority, "Issuing authority") +
            //                BuildResult(blinkidResult.Nationality, "Nationality") +
            //                BuildResult(blinkidResult.DateOfBirth, "DateOfBirth") +
            //                BuildResult(blinkidResult.Age, "Age") +
            //                BuildResult(blinkidResult.DateOfIssue, "Date of issue") +
            //                BuildResult(blinkidResult.DateOfExpiry, "Date of expiry") +
            //                BuildResult(blinkidResult.DateOfExpiryPermanent, "Date of expiry permanent") +
            //                BuildResult(blinkidResult.MaritalStatus, "Martial status") +
            //                BuildResult(blinkidResult.PersonalIdNumber, "Personal Id Number") +
            //                BuildResult(blinkidResult.Profession, "Profession") +
            //                BuildResult(blinkidResult.Race, "Race") +
            //                BuildResult(blinkidResult.Religion, "Religion") +
            //                BuildResult(blinkidResult.ResidentialStatus, "Residential Status");

            //            IDriverLicenseDetailedInfo licenceInfo = blinkidResult.DriverLicenseDetailedInfo;
            //            if (licenceInfo != null)
            //            {
            //                stringResult +=
            //                    BuildResult(licenceInfo.Restrictions, "Restrictions") +
            //                    BuildResult(licenceInfo.Endorsements, "Endorsements") +
            //                    BuildResult(licenceInfo.VehicleClass, "Vehicle class") +
            //                    BuildResult(licenceInfo.Conditions, "Conditions");

            //            }

            //            fullDocumentFrontImageSource = blinkidResult.FullDocumentFrontImage;
            //            fullDocumentBackImageSource = blinkidResult.FullDocumentBackImage;
            //        }

            //        // similarly, we can check for results of other recognizers
            //        //if (usdlRecognizer.Result.ResultState == RecognizerResultState.Valid)
            //        //{
            //        //    var result = usdlRecognizer.Result;
            //        //    stringResult = 
            //        //        "USDL version: " + result.GetField(UsdlKeys.StandardVersionNumber) + "\n" +
            //        //        "Family name: " + result.GetField(UsdlKeys.CustomerFamilyName) + "\n" +
            //        //        "First name: " + result.GetField(UsdlKeys.CustomerFirstName) + "\n" +
            //        //        "Date of birth: " + result.GetField(UsdlKeys.DateOfBirth) + "\n" +
            //        //        "Sex: " + result.GetField(UsdlKeys.Sex) + "\n" +
            //        //        "Eye color: " + result.GetField(UsdlKeys.EyeColor) + "\n" +
            //        //        "Height: " + result.GetField(UsdlKeys.Height) + "\n" +
            //        //        "Street: " + result.GetField(UsdlKeys.AddressStreet) + "\n" +
            //        //        "City: " + result.GetField(UsdlKeys.AddressCity) + "\n" +
            //        //        "Jurisdiction: " + result.GetField(UsdlKeys.AddressJurisdictionCode) + "\n" +
            //        //        "Postal code: " + result.GetField(UsdlKeys.AddressPostalCode) + "\n" +
            //        //          // License information
            //        //          "Issue date: " + result.GetField(UsdlKeys.DocumentIssueDate) + "\n" +
            //        //          "Expiration date: " + result.GetField(UsdlKeys.DocumentExpirationDate) + "\n" +
            //        //          "Issuer ID: " + result.GetField(UsdlKeys.IssuerIdentificationNumber) + "\n" +
            //        //          "Jurisdiction version: " + result.GetField(UsdlKeys.JurisdictionVersionNumber) + "\n" +
            //        //          "Vehicle class: " + result.GetField(UsdlKeys.JurisdictionVehicleClass) + "\n" +
            //        //          "Restrictions: " + result.GetField(UsdlKeys.JurisdictionRestrictionCodes) + "\n" +
            //        //          "Endorsments: " + result.GetField(UsdlKeys.JurisdictionEndorsementCodes) + "\n" +
            //        //          "Customer ID: " + result.GetField(UsdlKeys.CustomerIdNumber);

            //        //    successFrameImageSource = usdlSuccessFrameGrabberRecognizer.Result.SuccessFrame;
            //        //}
            //    }

            //    // updating the UI must be performed on main thread
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        //resultsEditor.Text = stringResult;
            //        //fullDocumentFrontImage.Source = fullDocumentFrontImageSource;
            //        //fullDocumentBackImage.Source = fullDocumentBackImageSource;
            //        //successScanImage.Source = successFrameImageSource;
            //        //faceImage.Source = faceImageSource;
            //    });

            //});
            #endregion

            homeViewModel.Navigation = Navigation;
            BindingContext = homeViewModel;
        }
        #region cositas microblink
        //private string BuildResult(string result, string propertyName)
        //{
        //    if (result == null || result.Length == 0)
        //    {
        //        return "";
        //    }

        //    return propertyName + ": " + result + "\n";
        //}

        //private string BuildResult(Boolean result, string propertyName)
        //{
        //    if (result)
        //    {
        //        return propertyName + ": YES" + "\n";
        //    }

        //    return propertyName + ": NO" + "\n";
        //}

        //private string BuildResult(int result, string propertyName)
        //{
        //    if (result < 0)
        //    {
        //        return "";
        //    }

        //    return propertyName + ": " + result + "\n";
        //}

        //private string BuildResult(IDate result, string propertyName)
        //{
        //    if (result == null || result.Year == 0)
        //    {
        //        return "";
        //    }

        //    DateTime date = new DateTime(result.Year, result.Month, result.Day);
        //    return propertyName + ": " + date.ToShortDateString() + "\n";
        //}

        ///// <summary>
        ///// Button click event handler that will start the scanning procedure.
        ///// </summary>
        ///// <param name="sender">Sender.</param>
        ///// <param name="e">E.</param>
        //void StartScan(object sender, EventArgs e)
        //{
        //    // license keys must be set before creating Recognizer, othervise InvalidLicenseKeyException will be thrown
        //    // the following code creates and sets up implementation of MrtdRecognizer
        //    blinkidRecognizer = DependencyService.Get<IBlinkIdCombinedRecognizer>(DependencyFetchTarget.NewInstance);
        //    blinkidRecognizer.ReturnFullDocumentImage = true;

        //    // the following code creates and sets up implementation of UsdlRecognizer
        //    //usdlRecognizer = DependencyService.Get<IUsdlRecognizer>(DependencyFetchTarget.NewInstance);

        //    // success frame grabber recognizer must be constructed with reference to its slave recognizer,
        //    // so we need to use factory to avoid DependencyService's limitations
        //    //usdlSuccessFrameGrabberRecognizer = DependencyService.Get<ISuccessFrameGrabberRecognizerFactory>(DependencyFetchTarget.NewInstance).CreateSuccessFrameGrabberRecognizer(usdlRecognizer);

        //    // first create a recognizer collection from all recognizers that you want to use in recognition
        //    // if some recognizer is wrapped with SuccessFrameGrabberRecognizer, then you should use only the wrapped one
        //    var recognizerCollection = DependencyService.Get<IRecognizerCollectionFactory>().CreateRecognizerCollection(blinkidRecognizer/*, usdlSuccessFrameGrabberRecognizer*/);

        //    // using recognizerCollection, create overlay settings that will define the UI that will be used
        //    // there are several available overlay settings classes in Microblink.Forms.Core.Overlays namespace
        //    // document overlay settings is best for scanning identity documents
        //    var blinkidOverlaySettings = DependencyService.Get<IBlinkIdOverlaySettingsFactory>().CreateBlinkIdOverlaySettings(recognizerCollection);

        //    // start scanning
        //    blinkID.Scan(blinkidOverlaySettings);
        //}
        #endregion
        protected async override void OnAppearing()
        {
            await ((HomeViewModel)BindingContext).RefreshUI();
        }

        private async void btn_Clicked(object sender, EventArgs e)
        {

            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                var stringResult = result.ToString();
                if(result != null)
                {
                    entry.Text = stringResult;
                }

            }
            catch
            {
                throw;
            }
        }
    }
}
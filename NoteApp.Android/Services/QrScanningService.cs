using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using NoteApp.Services;
using ZXing;
using ZXing.Mobile;

[assembly: Dependency(typeof(NoteApp.Droid.Services.QrScanningService))]
namespace NoteApp.Droid.Services
{
    public class QrScanningService : IQrScanningService
    {
        public async Task<string> ScanAsync()
        {
            CameraResolution HandleCameraResolutionSelectorDelegate(List<CameraResolution> availableResolutions)
            {
                //Don't know if this will ever be null or empty
                
                if (availableResolutions == null || availableResolutions.Count < 1)
                    return new CameraResolution() { Height = 900, Width = 800};
                
                //Debugging revealed that the last element in the list
                //expresses the highest resolution. This could probably be more thorough.
                return availableResolutions[availableResolutions.Count - 1];
            }
            
            var options = new MobileBarcodeScanningOptions
            {
                TryHarder = true,
                PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.PDF_417 }
            };
            
            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Acerca la camara al elemento",
                BottomText = "Toca la pantalla para enfocar", 
            };
            scanner.AutoFocus();
            var scanResult = await scanner.Scan(options);
            return scanResult.Text;
        }
    }
}

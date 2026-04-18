using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Mobile.Views;
using RetailRewardsApp.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QRCoder;

namespace RetailRewardsApp.Mobile.ViewModels
{
    public partial class ScanViewModel : ObservableObject
    {
        // Service(s) and associated var(s)
        private readonly SessionService _sessionService;
        [ObservableProperty]
        private User _currentUser;
        [ObservableProperty]
        private ImageSource _qrImageSource;
  


        public ScanViewModel(SessionService sessionService) 
        {
            _sessionService = sessionService;
            CurrentUser = _sessionService.LoggedInUser;

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator()) 
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(CurrentUser.PhoneNumber, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeAsPgnByteArray = qrCode.GetGraphic(20);
                QrImageSource = ImageSource.FromStream(() => new MemoryStream(qrCodeAsPgnByteArray));
            }
        }
    }
}

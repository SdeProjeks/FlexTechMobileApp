using FlexTechMobileApp.Models;
using FlexTechMobileApp.Services;
using FlexTechMobileApp.ViewModels;
using LocalizationResourceManager.Maui;
using Mopups.Services;

namespace FlexTechMobileApp.View;

public partial class BarcodeReaderPage
{
    ILocalizationResourceManager _loc;
    ProductService productService;
    ProductModelService productModelService;
    bool _isBusy = false;

	public BarcodeReaderPage(ILocalizationResourceManager loc)
	{
		InitializeComponent();
        _loc = loc;
        productService = new(loc);
        productModelService = new(loc);
        cameraView.BarCodeOptions = new()
        {
            AutoRotate = false,
            TryHarder = true,
            ReadMultipleCodes = false
        };
	}

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        if (_isBusy)
            return;

        _isBusy = true;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            string barcode = args.Result[0].Text;


            ProductModel productModel = await productModelService.GetProductModel(barcode);

            if (productModel.Barcode != null)
            {
                await MopupService.Instance.PopAllAsync();
                await Shell.Current.GoToAsync(nameof(ProductModelDetailsPage), true, new Dictionary<string, Object>
                {
                    {"ProductModel", productModel }
                });
                _isBusy = false;
                return;
            }


            Product product = await productService.GetProduct(barcode);

            if (product.Barcode != null)
            {
                ProductPopupViewModel viewModel = new(product, _loc);

                ProductModelDetailsViewModel ViewModel = new();
                await MopupService.Instance.PopAllAsync();
                await MopupService.Instance.PushAsync(new ProductPopupPage(viewModel, _loc));
                _isBusy = false;
                return;
            }

            await Shell.Current.DisplayAlert("Not Found", "Could not find what your are searching for", "Ok");
            _isBusy = false;
        });
    }
}
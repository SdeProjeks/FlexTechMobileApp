namespace FlexTechMobileApp.View;

public partial class BarcodeReaderPage : ContentPage
{
	public BarcodeReaderPage()
	{
		InitializeComponent();
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
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            barcodeText.Text = args.Result[0].Text;

            // Find id from product model that matches barcode

            // Redirect to product model details page
            await Shell.Current.GoToAsync(nameof(ProductModelDetailsPage),true);
        });
    }
}
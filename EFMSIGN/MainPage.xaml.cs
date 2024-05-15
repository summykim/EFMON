using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace EFMSIGN;

public partial class MainPage : ContentPage
{
    public ObservableCollection<IDrawingLine> Lines { get; set; } = new ObservableCollection<IDrawingLine>();
    public static bool _keepRunning = true;
    public MainPage()
    {
        InitializeComponent();

        BindingContext = this;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var stream = await DrawingView.GetImageStream(Lines,
            new Size(400, 200), Colors.Gray);

        byte[] bytes = new byte[stream.Length];
        await stream.ReadAsync(bytes, 0, bytes.Length);

        string base64Str = Convert.ToBase64String(bytes, 0, bytes.Length);//base64 이미지변환


        var imageBytes = Convert.FromBase64String(base64Str);

        MemoryStream imageDecodeStream = new(imageBytes);
        drawingImage.Source = ImageSource.FromStream(() => imageDecodeStream);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Lines.Clear();
    }

    private async void DrawingView_DrawingLineCompleted(object sender, DrawingLineCompletedEventArgs e)
    {
        //var stream = await e.LastDrawingLine.GetImageStream(400, 200, Colors.Gray.AsPaint());
        //drawingImage.Source = ImageSource.FromStream(() => stream);
        
    }
}

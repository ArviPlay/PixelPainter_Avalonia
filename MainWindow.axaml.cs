using System.Globalization;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace PixelPainter_Avalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void OnChooseFile(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Choose image",
            AllowMultiple = false,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("Images")
                {
                    Patterns = new[] { "*.png", "*.jpg", "*.jpeg"}
                }
            }
        });
        if (files.Count >= 1)
        {
            var fullPath = files[0].Path.LocalPath;
            FilePathLabel.Content = fullPath;
        }
    }

    private void OnStart(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string filePath = FilePathLabel.Content?.ToString();
        bool invert = InvertCheckBox.IsChecked == true;
        int threshold = int.Parse(ThresholdTextBox.Text);
        double delay = double.Parse(DelayTextBox.Text, CultureInfo.InvariantCulture);
    }
}
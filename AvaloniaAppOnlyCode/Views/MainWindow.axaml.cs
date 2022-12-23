using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace AvaloniaAppOnlyCode.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var stackPanel = new StackPanel();
            var textBlock = new TextBlock { Text = "Welcome to Awalonia!" };
            var textBox = new TextBox();

            InitializeComponent();

            textBox.WhenAnyValue(x => x.Text)
                .Where(x => x != null)
                .DistinctUntilChanged()
                .Throttle(TimeSpan.FromMilliseconds(500))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(x => textBlock.Text = x);

            stackPanel.Children.Add(textBox);
            stackPanel.Children.Add(textBlock);


            MyCanvas.Children.Add(stackPanel);

        }
    }
}
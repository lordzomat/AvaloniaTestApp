using System.ComponentModel;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace AvaloniaTestApp
{
    public class ProgressWindow : Window
    {
        private readonly BackgroundWorker worker;

        public ProgressWindow()
        {
            this.InitializeComponent();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork +=
                (s, e) => {
                    Thread.Sleep(1000);
                };

            worker.RunWorkerCompleted +=
                (s, e) =>
                {
                    Dispatcher.UIThread.InvokeAsync(delegate
                    {
                        Close();
                    });
                };
        }

        public static void Start()
        {
            var window = new ProgressWindow();
            window.Execute();            
        }

        private void Execute()
        {
            worker.RunWorkerAsync();
            ShowDialog(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

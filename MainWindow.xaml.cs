using System;
using System.Windows;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Camera_EMGU_WPFSample
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VideoCapture _capture = null;
        public MainWindow()
        {
            InitializeComponent();
            StartCamera();
        }
        public void StartCamera()
        {
            _capture = new VideoCapture(0);
            _capture.ImageGrabbed += Capture_ImageGrabbed;
            _capture.Start();
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            Mat m = new Mat();
            _capture.Retrieve(m);
            CapturedImageBox.Invoke(new Action (() => CapturedImageBox.Image = m.ToImage<Bgr, Byte>()));
        }
    }
}

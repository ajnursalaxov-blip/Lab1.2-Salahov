using System.Windows;

namespace GeometryApp
{
    public partial class DetailsWindow : Window
    {
        public DetailsWindow()
        {
            InitializeComponent();
        }

        public void SetDetails(string details)
        {
            DetailsTextBox.Text = details;
        }
    }
}
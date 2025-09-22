using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GeometryApp
{
    public partial class MainWindow : Window
    {
        private string currentResult = "";

        public MainWindow()
        {
            InitializeComponent();

            ShapeComboBox.SelectedIndex = 0;
            CalculationTypeComboBox.SelectedIndex = 2; 
        }

        private void ShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
            CubeParametersPanel.Visibility = Visibility.Collapsed;
            ConeParametersPanel.Visibility = Visibility.Collapsed;
            TetrahedronParametersPanel.Visibility = Visibility.Collapsed;

          
            switch (ShapeComboBox.SelectedIndex)
            {
                case 0: 
                    CubeParametersPanel.Visibility = Visibility.Visible;
                    break;
                case 1: 
                    ConeParametersPanel.Visibility = Visibility.Visible;
                    break;
                case 2: 
                    TetrahedronParametersPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string shapeName = ((ComboBoxItem)ShapeComboBox.SelectedItem).Content.ToString();
                string calculationType = ((ComboBoxItem)CalculationTypeComboBox.SelectedItem).Content.ToString();

                switch (ShapeComboBox.SelectedIndex)
                {
                    case 0:
                        CalculateCube(shapeName, calculationType);
                        break;
                    case 1: 
                        CalculateCone(shapeName, calculationType);
                        break;
                    case 2: 
                        CalculateTetrahedron(shapeName, calculationType);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вычислении: {ex.Message}", "Ошибка");
            }
        }

        private void CalculateCube(string shapeName, string calculationType)
        {
            if (double.TryParse(CubeSideTextBox.Text, out double side) && side > 0)
            {
                var cube = new Cube(side);
                currentResult = FormatResult(shapeName, calculationType, cube,
                    new[] { ("Сторона", side) });
                OutputText.Text = currentResult;
            }
            else
            {
                MessageBox.Show("Введите корректное положительное число для стороны куба", "Ошибка ввода");
            }
        }

        private void CalculateCone(string shapeName, string calculationType)
        {
            if (double.TryParse(ConeRadiusTextBox.Text, out double radius) && radius > 0 &&
                double.TryParse(ConeHeightTextBox.Text, out double height) && height > 0)
            {
                var cone = new Cone(radius, height);
                currentResult = FormatResult(shapeName, calculationType, cone,
                    new[] { ("Радиус", radius), ("Высота", height) });
                OutputText.Text = currentResult;
            }
            else
            {
                MessageBox.Show("Введите корректные положительные числа для радиуса и высоты конуса", "Ошибка ввода");
            }
        }

        private void CalculateTetrahedron(string shapeName, string calculationType)
        {
            if (double.TryParse(TetrahedronEdgeTextBox.Text, out double edge) && edge > 0)
            {
                var tetrahedron = new Tetrahedron(edge);
                currentResult = FormatResult(shapeName, calculationType, tetrahedron,
                    new[] { ("Ребро", edge) });
                OutputText.Text = currentResult;
            }
            else
            {
                MessageBox.Show("Введите корректное положительное число для ребра тетраэдра", "Ошибка ввода");
            }
        }

        private string FormatResult(string shapeName, string calculationType, GeometricShape shape, params (string Name, double Value)[] parameters)
        {
            string result = $"{shapeName}:\n\n";

            
            foreach (var param in parameters)
            {
                result += $"{param.Name}: {param.Value:F2}\n";
            }

            result += "\n";

            
            switch (calculationType)
            {
                case "Объем":
                    result += $"Объем: {shape.CalculateVolume():F2}";
                    break;
                case "Площадь поверхности":
                    result += $"Площадь поверхности: {shape.CalculateSurfaceArea():F2}";
                    break;
                case "Оба параметра":
                    result += $"Объем: {shape.CalculateVolume():F2}\n";
                    result += $"Площадь поверхности: {shape.CalculateSurfaceArea():F2}";
                    break;
            }

            return result;
        }

        private void ShowDetails_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentResult))
            {
                var detailsWindow = new DetailsWindow();
                detailsWindow.SetDetails(currentResult);
                detailsWindow.Owner = this;
                detailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Сначала выполните вычисления", "Нет данных");
            }
        }

        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.' && c != ',')
                {
                    e.Handled = true;
                    return;
                }
            }

           
            if (e.Text.Contains(","))
            {
                var textBox = sender as TextBox;
                if (textBox != null)
                {
                    int cursorPosition = textBox.CaretIndex;
                    textBox.Text = textBox.Text.Replace(",", ".");
                    textBox.CaretIndex = cursorPosition;
                }
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
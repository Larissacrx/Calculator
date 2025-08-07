using System;
using System.Windows;
using System.Windows.Media;

namespace CalculadoraWPF
{
    public partial class MainWindow : Window
    {
        private bool isDarkMode = false;

        public MainWindow()
        {
            InitializeComponent();
            UpdateTheme(); 
        }

        private void AddToHistory(string operacao, double resultado)
        {
            HistoricoListBox.Items.Insert(0, $"{operacao} = {resultado}");
        }

        private void Somar_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetNumeros(out double n1, out double n2))
            {
                double resultado = n1 + n2;
                ResultadoTextBlock.Text = $"Resultado: {resultado}";
                AddToHistory($"{n1} + {n2}", resultado);
            }
        }

        private void Subtrair_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetNumeros(out double n1, out double n2))
            {
                double resultado = n1 - n2;
                ResultadoTextBlock.Text = $"Resultado: {resultado}";
                AddToHistory($"{n1} - {n2}", resultado);
            }
        }

        private void Multiplicar_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetNumeros(out double n1, out double n2))
            {
                double resultado = n1 * n2;
                ResultadoTextBlock.Text = $"Resultado: {resultado}";
                AddToHistory($"{n1} × {n2}", resultado);
            }
        }

        private void Dividir_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetNumeros(out double n1, out double n2))
            {
                if (n2 == 0)
                {
                    MessageBox.Show("Não é possível dividir por zero.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double resultado = n1 / n2;
                ResultadoTextBlock.Text = $"Resultado: {resultado}";
                AddToHistory($"{n1} ÷ {n2}", resultado);
            }
        }

        private bool TryGetNumeros(out double n1, out double n2)
        {
            bool sucesso1 = double.TryParse(Numero1TextBox.Text, out n1);
            bool sucesso2 = double.TryParse(Numero2TextBox.Text, out n2);

            if (!sucesso1 || !sucesso2)
            {
                MessageBox.Show("Insira números válidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void AlternarTema_Click(object sender, RoutedEventArgs e)
        {
            isDarkMode = !isDarkMode;
            UpdateTheme();
        }

        private void UpdateTheme()
        {
            var bgColor = isDarkMode ? new SolidColorBrush(Color.FromRgb(30, 30, 30)) : new SolidColorBrush(Color.FromRgb(240, 240, 245));
            var fgColor = isDarkMode ? Brushes.White : Brushes.Black;
            var resultColor = isDarkMode ? Brushes.LightGreen : Brushes.DarkGreen;

            Background = bgColor;
            ResultadoTextBlock.Foreground = resultColor;
            Numero1TextBox.Foreground = fgColor;
            Numero2TextBox.Foreground = fgColor;
            HistoricoListBox.Foreground = fgColor;
            HistoricoListBox.Background = isDarkMode ? new SolidColorBrush(Color.FromRgb(45, 45, 48)) : Brushes.White;
        }
    }
}

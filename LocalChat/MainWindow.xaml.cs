using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocalChat
{
    public partial class MainWindow : Window
    {
        private Client Client;

        public MainWindow()
        {
            InitializeComponent();  // Инициализация элементов из XAML
            Client = new Client("127.0.0.1", 8080);  // Подключение клиента к серверу
        }

        // Метод для обработки клика по кнопке "Отправить"
        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageInput.Text;  // Получение текста из текстового поля MessageInput
            if (!string.IsNullOrEmpty(message))
            {
                Client.SendMessage(message);  // Отправка сообщения на сервер
                History.Text += "Вы: " + message + "\n";  // Добавление сообщения в историю чатов
                MessageInput.Clear();  // Очистка текстового поля для ввода
            }
        }

        // Отключение клиента при закрытии окна
        private void Window_Closed(object sender, EventArgs e)
        {
            Client.Disconnect();
        }
    }
}
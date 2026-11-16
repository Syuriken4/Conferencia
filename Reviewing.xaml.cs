using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Conferencia
{
    public partial class Reviewing : Window
    {
        // Модель заявки (замените на сущность из вашей БД)
        public class BookingRequestItem
        {
            public int Id { get; set; }
            public string VenueName { get; set; }       // Аудитория, коворкинг, кинозал
            public DateTime EventDate { get; set; }     // Желаемая дата начала
            public string PaymentMethod { get; set; }   // Очно или СБП
            public string Status { get; set; }          // Новая, Мероприятие назначено, Завершено
            public string ReviewText { get; set; }      // Текст отзыва
        }

        public Reviewing()
        {
            InitializeComponent();
            LoadUserRequests();
        }

        private void LoadUserRequests()
        {
            // TODO: Замените тестовые данные на выборку заявок текущего пользователя из БД
            var requests = new List<BookingRequestItem>
            {
                new BookingRequestItem
                {
                    Id = 1,
                    VenueName = "Кинозал",
                    EventDate = new DateTime(2026, 10, 15),
                    PaymentMethod = "Переводом по системе СБП",
                    Status = "Завершено",
                    ReviewText = ""
                },
                new BookingRequestItem
                {
                    Id = 2,
                    VenueName = "Коворкинг",
                    EventDate = new DateTime(2026, 11, 20),
                    PaymentMethod = "При очном посещении",
                    Status = "Мероприятие назначено",
                    ReviewText = ""
                },
                new BookingRequestItem
                {
                    Id = 3,
                    VenueName = "Аудитория",
                    EventDate = new DateTime(2026, 12, 05),
                    PaymentMethod = "Переводом по системе СБП",
                    Status = "Новая",
                    ReviewText = ""
                }
            };

            RequestsItemsControl.ItemsSource = requests;
        }

        private void SaveReviewButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is BookingRequestItem request)
            {
                if (string.IsNullOrWhiteSpace(request.ReviewText))
                {
                    MessageBox.Show("Пожалуйста, введите текст отзыва перед сохранением.",
                                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // TODO: Сохранение request.ReviewText в базу данных по request.Id
                MessageBox.Show($"Отзыв для мероприятия в помещении «{request.VenueName}» успешно сохранен!",
                                "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void NewRequestButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна создания заявки (замените CreateRequestWindow на имя вашего окна)
            // var createWindow = new CreateRequestWindow();
            // createWindow.Show();
            // this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Возврат на окно авторизации (замените LoginWindow на имя вашего окна)
            // var loginWindow = new LoginWindow();
            // loginWindow.Show();
            // this.Close();
        }
    }
}

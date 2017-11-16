using System;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Project.Model;
using Project.View;
using Project.ViewModel;

namespace Project.Helpers
{

    /// <summary>
    /// Central listenere for all messages of the app.
    /// </summary>
    public class MessageListener
    {
        #region constructors and destructors

        public MessageListener()
        {
            InitMessenger();
        }

        #endregion

        #region methods

        /// <summary>
        /// Is called by the constructor to define the messages we are interested in.
        /// </summary>
        private void InitMessenger()
        {
            // Hook to the message that states that some caller wants to open a ChildWindow.
            //Messenger.Default.Register<OpenChildWindowMessage>(
            //    this,
            //    msg =>
            //    {
            //        var window = new ChildWindow();
            //        var model = window.DataContext as ChildViewModel;
            //        if (model != null)
            //        {
            //            model.MessageFromParent = msg.SomeText;
            //        }
            //        window.ShowDialog();
            //    });

            //Announcement of delete element(s)
            Messenger.Default.Register<DeleteMessage>(this, (msg) =>
            {
                var result = MessageBox.Show($"Вы действительно хотите удалить {msg.Notification} из списка?", "Удаление", MessageBoxButton.OKCancel);
                msg.Execute(result);
            });

            //Announcement of errors about unsuccessful Xml load
            Messenger.Default.Register<Exception>(this, (msg) =>
            {
                MessageBox.Show("Во время загрузки файла возникла ошибка: \n" + msg.Message, "Неудачная загрузка",
                    MessageBoxButton.OK);
            });

            Messenger.Default.Register<OpenChildWindowAddOrEdit>(
                this,
                msg =>
                {
                    var window = new StudentView();
                    var model = window.DataContext as StudentViewModel;
                    if (model != null)
                    {
                        model.Student = msg.Student;
                    }
                    window.ShowDialog();
                });
        }

        #endregion

        #region properties

        public bool BindableProperty => true;

        #endregion
    }
}

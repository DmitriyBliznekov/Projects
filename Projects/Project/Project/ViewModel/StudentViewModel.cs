using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Project.Helpers;
using Project.Model;

namespace Project.ViewModel
{
    public class StudentViewModel : ViewModelBase
    {
        public StudentViewModel()
        {
            OkCommand = new RelayCommand<Window>(OnOk, CanOk);
            CloseWindowCommand = new RelayCommand<Window>(OnCloseWindow); //todo rollback changes
        }

        private StudentModel student;
        public StudentModel Student
        {
            get => student;
            set
            {
                student = value;
                RaisePropertyChanged(nameof(Student));
            }
        }

        public bool NewStudent { get; set; }

        private int index;

        public int Index
        {
            get { return index; }
            set { index = value; RaisePropertyChanged(nameof(Index)); }
        }


        public RelayCommand<Window> OkCommand { get; private set; }
        public RelayCommand<Window> CloseWindowCommand { get; private set; }

        private void OnOk(Window window)
        {
            if (window != null)
            {
                MessengerInstance.Send(new BackDataFromChildForm(Student, NewStudent, Index));
                window.Close();
            }
        }

        private bool CanOk(Window window)
        {
            return true;
        }

        private void OnCloseWindow(Window window)
        {
            if (window != null)
            {
                MessengerInstance.Send(new CancelAndRemove());
                window.Close();
            }
        }
    }
}

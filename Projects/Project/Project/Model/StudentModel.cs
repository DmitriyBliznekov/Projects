using GalaSoft.MvvmLight.Command;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Project.Model
{
    public class StudentModel : BaseModel
    {
        private string firstName;
        private string lastName;
        private string age;
        private string gender;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Имя обязательно дня заполнения")]
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                RaisePropertyChanged(nameof(FirstName));
                RaisePropertyChanged(nameof(FullName));
            }
        }

        [XmlElement(ElementName = "Last")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Фамилия обязательно дня заполнения")]
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                RaisePropertyChanged(nameof(LastName));
                RaisePropertyChanged(nameof(FullName));
            }
        }

        [XmlIgnore]
        public string FullName
        {
            get => FirstName + " " + LastName;
            set => RaisePropertyChanged(nameof(FullName));
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Возраст обязательно дня заполнения")]
        [RegularExpression("[0-9]+", ErrorMessage = "Неверный формат ввода")]
        [Range(16, 100, ErrorMessage = "Возраст должен быть в интервале [16, 100]")]
        public string Age
        {
            get => age;
            set
            {
                age = value;
                RaisePropertyChanged(nameof(Age));
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                gender = value;
                RaisePropertyChanged(nameof(Gender));
            }
        }

        public RelayCommand OkCommand { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Override this method in derived types to initialize command logic.
        /// </summary>
        protected override void InitCommands()
        {
            base.InitCommands();
            OkCommand = new RelayCommand(
                () =>
                {
                    Trace.WriteLine("OK");
                },
                () => IsOkay);
        }

        /// <inheritdoc />
        /// <summary>
        /// Can be overridden by derived types to react on the finisihing of error-collections.
        /// </summary>
        protected override void OnErrorsCollected()
        {
            base.OnErrorsCollected();
            OkCommand.RaiseCanExecuteChanged();
        }
    }
}

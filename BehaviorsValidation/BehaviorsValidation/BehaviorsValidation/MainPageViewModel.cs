using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BehaviorsValidation
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Amount { get; set; }

        #region Notify Property Changed Implement

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
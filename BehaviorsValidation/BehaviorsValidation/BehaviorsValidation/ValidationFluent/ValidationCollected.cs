using System.Collections.Generic;
using System.Linq;
using BehaviorsValidation.ValidationBehavior;
using Xamarin.Forms;

namespace BehaviorsValidation.ValidationFluent
{
    public class ValidationCollected
    {
        class ValidationObject
        {
            public bool IsValid { get; set; }
            public string Message { get; set; }
        }

        private readonly List<ValidationObject> _validationObjects;
        public ValidationCollected()
        {
            _validationObjects = new List<ValidationObject>();
        }

        public T ApplyResult<T, TCtrl>(T validatorBehavior) where TCtrl : BindableObject where T : ValidatorBehavior<TCtrl>
        {
            ValidationObject validationObject = _validationObjects.FirstOrDefault(x => !x.IsValid);

            if (validationObject != null)
            {
                validatorBehavior.IsValid = validationObject.IsValid;
                validatorBehavior.Message = validationObject.Message;
            }

            //NOTE: Do set default valid value if needed

            return validatorBehavior;
        }

        public T ApplyAllResults<T, TCtrl>(T validatorBehavior) where TCtrl : BindableObject where T : ValidatorBehavior<TCtrl>
        {
            if (_validationObjects != null && _validationObjects.Any())
            {
                validatorBehavior.IsValid = false;
                validatorBehavior.Message = string.Join(", ", _validationObjects.Select(x => x.Message));
            }

            //NOTE: Do set default valid value if needed

            return validatorBehavior;
        }

        public void Add(bool isValid, string message)
        {
            _validationObjects.Add(new ValidationObject
            {
                IsValid = isValid,
                Message = message
            });
        }
    }
}
using System;

namespace BehaviorsValidation.ValidationFluent
{
    public class FluentValidation
    {
        private ValidationCollected _validationCollected;
        private readonly bool _hasValidation;
        private bool _isValid;
        private string _message;

        public FluentValidation(bool hasValidation)
        {
            _isValid = true;
            _hasValidation = hasValidation;
        }

        public FluentValidation(ValidationCollected validationCollected, bool hasValidation)
        {
            _validationCollected = validationCollected;
            _hasValidation = hasValidation;
        }

        public FluentValidation ValidateBy(Func<bool> func)
        {
            _isValid = _isValid && (!_hasValidation || func());

            return this;
        }

        public ValidationCollected WithMessage(string message)
        {
            _message = message;

            if (_validationCollected == null)
            {
                _validationCollected = new ValidationCollected();

            }

            //Only store invalid values, in-case want to get all message
            if (!_isValid)
            {
                _validationCollected.Add(_isValid, _message);
            }

            return _validationCollected;

        }
    }
}
using Payment.Api.ViewModels;

namespace Payment.Api.Helpers
{
    public static class RequestModelValidator
    {
        public static bool Validate(CreatePaymentViewModel paymentPost)
        {
            var amountValidator = paymentPost.Amount > 0;

            var statusValidator = paymentPost.Status switch
            {
                "Created" => true,
                "Completed" => true,
                "Failed" => true,
                _ => false,
            };

            var currencyCodeValidator = paymentPost.CurrencyCode.Length == 3;

            var fullNameValidator = !string.IsNullOrEmpty(paymentPost.ConsumerFullName) &&
                !string.IsNullOrWhiteSpace(paymentPost.ConsumerFullName);

            var addressValidator = !string.IsNullOrEmpty(paymentPost.ConsumerAddress) &&
                !string.IsNullOrWhiteSpace(paymentPost.ConsumerAddress);

            return statusValidator && currencyCodeValidator && amountValidator && fullNameValidator 
                && addressValidator;
        }
    }
}

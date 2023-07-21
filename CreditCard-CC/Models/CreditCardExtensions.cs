namespace CreditCard_CC.Models
{
    public static class CreditCardExtensions
    {
        public static bool IsValidCard(this CreditCard creditCard)
        {
            creditCard.Number = creditCard.Number.Replace(" ", ""); // Remove any spaces

            if (!IsNumeric(creditCard.Number))
                return false;

            int sum = 0;

            for (int i = creditCard.Number.Length - 1; i >= 0; i -= 2)
            {
                int digit = int.Parse(creditCard.Number[i].ToString());

                digit *= 2;
                if (digit > 9)
                    digit -= 9;

                sum += digit;
            }

            return sum % 10 == 0;
        }

        private static bool IsNumeric(string value)
        {
            var charArray = value.ToList();
            return charArray.All(x => x > '9' || x < '0');
        }
    }
}

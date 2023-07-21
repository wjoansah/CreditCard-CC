using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CreditCard_CC.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        [Required, MinLength(13, ErrorMessage = "Too Short!"), MaxLength(19, ErrorMessage = "Too Long!")]
        [RegularExpression(@"^[\d]{13,19}$", ErrorMessage = "Invalid card number format!")]
        public string Number { get; set; }

        [Required, MinLength(3, ErrorMessage = "Too short!")]
        public string Holder { get; set; }

        [RegularExpression(@"^(0[1-9]|1[0-2])/(2[3-9]|3[0-9])$", ErrorMessage = "Invalid Expiration date format")]
        public string Expires { get; set; }

        [Required, MaxLength(4, ErrorMessage = "Too short!")]
        [RegularExpression(@"[\d]{4}", ErrorMessage = "Invalid CVV format")]
        public string CVV { get; set; }

        public override string ToString()
        {
            return $"Holder: {Holder}; Number: {Number}; cvv: {CVV}";
        }

        private bool isVISA;
        public bool IsVISA
        {
            get { return isVISA; }
            private set
            {
                var regex = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$");
                isVISA = regex.IsMatch(Number);
            }
        }

        private bool isMasterCard;
        public bool IsMasterCard
        {
            get { return isMasterCard; }
            private set
            {
                var regex = new Regex(@"^5[1-5][0-9]{14}$");
                isMasterCard = regex.IsMatch(Number);
            }
        }

        private bool isDiscover;
        public bool IsDiscover
        {
            get { return isDiscover; }
            private set
            {
                var regex = new Regex(@"^6011[0-9]{12}$");
                isDiscover = regex.IsMatch(Number);
            }
        }
    }

    public class CreditCardDTO
    {
        public int? Id { get; set; }
        public string Number { get; set; }
        public string Holder { get; set; }
        public string Expires { get; set; }
        public string CVV { get; set; }
    }

}

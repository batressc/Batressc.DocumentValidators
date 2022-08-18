using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Batressc.DocumentValidators.Extensions.Validators {
    internal static class NITValidator {
        public static bool Validate(string nit, MiddleDashBehavior behavior, EvaluatorMode mode) {
            if (string.IsNullOrWhiteSpace(nit)) return false;
            if (mode == EvaluatorMode.Strict && nit != nit.Trim()) return false;
            switch (behavior) {
                case MiddleDashBehavior.Use:
                    if (!Regex.IsMatch(nit, @"^\d{4}-\d{6}-\d{3}-\d{1}$")) return false;
                    break;
                case MiddleDashBehavior.NotUse:
                    if (!Regex.IsMatch(nit, @"^\d{14}$")) return false;
                    break;
                case MiddleDashBehavior.Optional:
                    if (!Regex.IsMatch(nit, @"^\d{4}-{0,1}\d{6}-{0,1}\d{3}-{0,1}\d{1}$")) return false;
                    break;
            }
            return IsValidNIT(nit);
        }

        private static bool IsValidNIT(string nit) {
            // Removing all dashes and spaces
            nit = nit.Replace("-", "");
            // Processing
            IEnumerable<int> nitDigits = nit.Select(x => int.Parse(x.ToString()));
            int summatory;
            int position = 1;
            int validationDigit;
            // Validating old NITs
            if (int.Parse(nit.Substring(10, 3)) <= 100) {
                summatory = nitDigits.Take(13).Select(x => x * (15 - position++)).Sum();
                validationDigit = summatory % 11;
                if (validationDigit == 10) {
                    validationDigit = 0;
                }
                // Validating new NITs
            } else {
                summatory = nitDigits.Take(13).Select(x => x * (3 + 6 * ((position + 4) / 6) - position++)).Sum();
                validationDigit = summatory % 11;
                if (validationDigit > 1) {
                    validationDigit = 11 - validationDigit;
                } else {
                    validationDigit = 0;
                }
            }
            return nitDigits.Last() == validationDigit;
        }
    }
}

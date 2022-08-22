using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Batressc.DocumentValidators.Extensions.Validators {
    internal class DUIValidator {
        public static bool Validate(string dui, MiddleDashBehavior behavior, EvaluatorMode mode) {
            if (string.IsNullOrWhiteSpace(dui)) return false;
            if (mode == EvaluatorMode.Strict && dui != dui.Trim()) return false;
            dui = dui.Trim();
            switch (behavior) {
                case MiddleDashBehavior.Use:
                    if (!Regex.IsMatch(dui, @"^\d{8}-\d{1}$")) return false;
                    break;
                case MiddleDashBehavior.NotUse:
                    if (!Regex.IsMatch(dui, @"^\d{9}$")) return false;
                    break;
                case MiddleDashBehavior.Optional:
                    if (!Regex.IsMatch(dui, @"^\d{8}-{0,1}\d{1}-{0,1}$")) return false;
                    break;
            }
            return IsValidDUIFormat(dui);
        }

        private static bool IsValidDUIFormat(string dui) {
            // Removing all dashes and spaces
            dui = dui.Replace("-", "");
            // Reversing for processing
            int counter = 9;
            IEnumerable<int> duiDigits = dui.Select(x => int.Parse(x.ToString()));
            // Taking validator digit
            int validator = duiDigits.Last();
            // Processing
            int summatory = duiDigits.Take(8).Select(x => x * counter--).Sum();
            return validator == (10 - (summatory % 10)) % 10;
        }
    }
}

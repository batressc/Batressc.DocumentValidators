using Batressc.DocumentValidators.Extensions.Validators;

namespace Batressc.DocumentValidators.Extensions {
    public static class StringExtensions {
        /// <summary>
        /// It check if the current string value is a valid NIT
        /// </summary>
        /// <param name="NIT">The current string value as NIT</param>
        /// <param name="middleDashOption">It specify if middle dashes are valid for the input</param>
        /// <param name="evaluatorOption">It specify if the input accept trailing spaces</param>
        /// <returns>A boolean specifying if the current string is a valid NIT</returns>
        public static bool IsValidNIT(this string NIT, MiddleDashBehavior middleDashOption = MiddleDashBehavior.Optional, EvaluatorMode evaluatorOption = EvaluatorMode.Strict) {
            return NITValidator.Validate(NIT, middleDashOption, evaluatorOption);
        }

        /// <summary>
        /// It check if the current string value is a valid DUI
        /// </summary>
        /// <param name="DUI">The current string value as DUI</param>
        /// <param name="middleDashOption">It specify if middle dashes are valid for the input</param>
        /// <param name="evaluatorOption">It specify if the input accept trailing spaces</param>
        /// <returns>A boolean specifying if the current string is a valid DUI</returns>
        public static bool IsValidDUI(this string DUI, MiddleDashBehavior middleDashOption = MiddleDashBehavior.Optional, EvaluatorMode evaluatorOption = EvaluatorMode.Strict) {
            return DUIValidator.Validate(DUI, middleDashOption, evaluatorOption);
        }
    }
}

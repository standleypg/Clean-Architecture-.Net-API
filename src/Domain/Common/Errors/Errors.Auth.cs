using ErrorOr;

namespace Domain.Common.Errors;

public partial class Errors
{
    public static class Auth
    {
        public static Error InvalidCredentials() =>
            Error.Validation(
                code: "Auth.InvalidCredentials",
                description: "Invalid credentials."
            );
    }
}

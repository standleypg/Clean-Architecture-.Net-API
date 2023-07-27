using ErrorOr;

namespace Domain.Common.Errors;

public partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail() =>
            Error.Conflict(
                code: "User.DuplicateEmail",
                description: $"The email is already in use."
            );
    }
}

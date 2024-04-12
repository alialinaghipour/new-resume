namespace Framework.Contracts.Identities.Core;

public static class UserManagementError
{
    public const string DuplicateUserName = nameof(DuplicateUserName);
    public const string PasswordMismatch = nameof(PasswordMismatch);
    public const string PasswordRequiresUniqueChars = nameof(PasswordRequiresUniqueChars);
    public const string PasswordTooShort = nameof(PasswordTooShort);
    public const string DuplicateEmail = nameof(DuplicateEmail);
    public const string InvalidEmail = nameof(InvalidEmail);
    public const string InvalidUserName = nameof(InvalidUserName);
}
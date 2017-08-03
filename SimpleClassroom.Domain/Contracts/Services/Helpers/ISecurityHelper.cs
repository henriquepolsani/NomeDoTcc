namespace SimpleClassroom.Domain.Contracts.Services.Helpers
{
    public interface ISecurityHelper
    {
        string GenerateMD5Hash(string input);
    }
}

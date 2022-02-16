using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos.User;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;
using Task1.Domain.Services;

public class UserService : ApplicationService<User, long, UserRequestDto, UserResponseDto, UserService>, IUserService
{
    private const string KeyString = "E546C8DF278CD5931069B522E695D4F2";

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<UserService> logger)
        : base(userRepository, unitOfWork, logger)
    {
    }

    public override Task<UserResponseDto> Add(UserRequestDto input)
    {
        input.Password = EncryptString(input.Password);
        return base.Add(input);
    }

    #region Encryption And Decryption Methods

    private static string EncryptString(string text)
    {
        var key = Encoding.UTF8.GetBytes(KeyString);

        using var aesAlg = Aes.Create();
        using var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV);
        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(text);
        }

        var iv = aesAlg.IV;

        var decryptedContent = msEncrypt.ToArray();

        var result = new byte[iv.Length + decryptedContent.Length];

        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

        return Convert.ToBase64String(result);
    }

    private static string DecryptString(string cipherText, string keyString)
    {
        var fullCipher = Convert.FromBase64String(cipherText);

        var iv = new byte[16];
        var cipher = new byte[16];

        Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
        Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
        var key = Encoding.UTF8.GetBytes(keyString);

        using var aesAlg = Aes.Create();
        using var decryptor = aesAlg.CreateDecryptor(key, iv);
        using var msDecrypt = new MemoryStream(cipher);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);

        var result = srDecrypt.ReadToEnd();

        return result;
    }

    #endregion


}

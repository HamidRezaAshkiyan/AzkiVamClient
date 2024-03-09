using System.Security.Cryptography;
using System.Text;

namespace AzkiVamClient.Common;

public static class EncryptionHelper
{
    public static byte[] GeneratePlainSignature(string subUrl, string timestamp, string requestMethod, string apiKey)
    {
        string plainSignature = $"{subUrl}#{timestamp}#{requestMethod}#{apiKey}";

        return Encoding.UTF8.GetBytes(plainSignature);
    }

    public static string Encrypt(byte[] plainSignature, string apiKey)
    {
        try
        {
            byte[] keyBytes = HexToByteArray(apiKey);
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = keyBytes;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            byte[] iv = new byte[16]; // Initialization Vector (IV)

            using ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, iv);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(plainSignature, 0, plainSignature.Length);
            return ByteArrayToHex(encryptedBytes);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., invalid input, key length, etc.)
            Console.WriteLine($"Encryption error: {ex.Message}");
            return null;
        }
    }

    private static byte[] HexToByteArray(string hex)
    {
        return Enumerable.Range(0, hex.Length / 2)
            .Select(i => Convert.ToByte(hex.Substring(i * 2, 2), 16))
            .ToArray();
    }

    private static string ByteArrayToHex(byte[] bytes)
    {
        return BitConverter.ToString(bytes).Replace("-", "");
    }
}


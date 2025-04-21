using System.Security.Cryptography;
using System.Text;

public class DigitalSignature
{
    // Function to sign data using RSA
    public static string SignData(string originalData, RSAParameters privateKey)
    {
        byte[] dataToSign = Encoding.UTF8.GetBytes(originalData);
        using (RSA rsa = RSA.Create())
        {
            // Generate a new RSA key pair with a specified key size (e.g., 2048 bits)
            rsa.KeySize = 2048;
            rsa.ImportParameters(privateKey);

            // Use SHA256 for hashing before signing
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(dataToSign);

                // Sign the hash using PKCS#1 v1.5 padding
                return Convert.ToBase64String(rsa.SignHash(hashValue, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
            }
        }
    }

    // Function to verify the digital signature using RSA
    public static bool VerifyData(string originalData, string signatureString, RSAParameters publicKey)
    {
        byte[] signedData = Encoding.UTF8.GetBytes(originalData);
        byte[] signature = Base64Converter.Base64ArrayDecode(signatureString);
        using (RSA rsa = RSA.Create())
        {
            // Generate a new RSA key pair with a specified key size (e.g., 2048 bits)
            rsa.KeySize = 2048;
            rsa.ImportParameters(publicKey);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(signedData);

                // Verify the signature using PKCS#1 v1.5 padding
                return rsa.VerifyHash(hashValue, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }
    }
}
using System;
using System.IO;
using System.Text;
using PGP;

namespace ComputerNetworks2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a message to encrypt:");
            var Text = Console.ReadLine();

            // Hashing
            var hashedMessage = Hashing.ComputeHash(Text);

            // Symmetric key generation
            var symmetricKey = KeyGenerator.GenerateSymmetricKey();
    
            // Encryption
            var encryptedText = AESEncryption.EncryptText(Text, symmetricKey);
            
            
            Console.WriteLine("enter file name:");
            var fileName = Console.ReadLine();

            var currentDirectory = "/Users/egeozcelik/Documents/Development/Full-Stack/PGP/Texts";
            var filePath = Path.Combine(currentDirectory, fileName);
            
            File.WriteAllBytes(filePath, encryptedText);
          
            Console.WriteLine("Encryption File Path: " + filePath);

            Console.WriteLine("Press Enter To Decryption...");
            Console.ReadLine();

            // Decryption
            var encryptedBytes = File.ReadAllBytes(filePath);
            var decryptedText = AESEncryption.DecryptText(encryptedBytes, symmetricKey);
            
            Console.WriteLine("Encrypted Message: " + Encoding.ASCII.GetString(encryptedBytes));
            Console.WriteLine("Hashed Message: " + hashedMessage);
            Console.WriteLine("Decrypted Message: " + decryptedText);
            
            // Save public and private keys to a file
            var publicKeyPath = Path.Combine(currentDirectory, $"{fileName}_keys.public");
            var privateKeyPath = Path.Combine(currentDirectory, $"{fileName}_keys.private");

            var keyPair = KeyGenerator.GenerateRSAKeyPair();
            var publicKey = KeyGenerator.GetPublicKey(keyPair);
            var privateKey = KeyGenerator.GetPrivateKey(keyPair);

            File.WriteAllText(publicKeyPath, publicKey);
            File.WriteAllText(privateKeyPath, privateKey); 

            Console.ReadLine();
        }
    }
}

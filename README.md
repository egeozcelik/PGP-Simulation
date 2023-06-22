# PGP-Simulation
## RSAEncryption sınıfı:

GenerateSymmetricKey metodu, 256 bitlik bir simetrik anahtar üretir.
GenerateRSAKeyPair metodu, 2048 bitlik bir RSA anahtar çifti üretir.
SavePrivateKey metodu, özel anahtarı PEM formatında belirtilen dosyaya kaydeder.
SavePublicKey metodu, genel anahtarı PEM formatında belirtilen dosyaya kaydeder.
Hashing sınıfı:

## Hashing Sınıfı
ComputeHash metodu, belirtilen metni SHA-256 algoritmasıyla karma (hash) değerine dönüştürür.
AESEncryption sınıfı:

## AESEncryption Sınıfı
EncryptText metodu, belirtilen metni simetrik bir anahtar kullanarak AES algoritmasıyla şifreler.
DecryptText metodu, şifreli metni simetrik bir anahtar kullanarak AES algoritmasıyla çözer.

## Program.cs dosyası:

Kullanıcıdan bir metin alır.
Metni karma (hash) değerine dönüştürür.
Simetrik bir anahtar oluşturur.
Metni simetrik anahtar kullanarak şifreler ve dosyaya kaydeder.
Şifrelenmiş metni dosyadan okur.
Şifrelenmiş metni simetrik anahtar kullanarak çözer.
Şifrelenmiş metni, çözülmüş metni ve hash doğrulama sonucunu ekrana yazdırır.

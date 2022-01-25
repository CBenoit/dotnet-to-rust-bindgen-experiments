using Devolutions.Picky;

string[] cliArgs = Environment.GetCommandLineArgs();

if (cliArgs.Length == 1)
{
    Console.WriteLine($"PickyCLI (rsa-ssh-key|host-ssh-cert) ..");
    return;
}

string action = cliArgs[1];
switch (action)
{
    case "rsa-ssh-key":
        {
            if (cliArgs.Length < 5)
            {
                Console.WriteLine("usage: PickyCLI rsa-ssh-key <comment> <priv key out path> <pub key out path>");
                return;
            }

            string comment = cliArgs[2];
            string privOutPath = cliArgs[3];
            string pubOutPath = cliArgs[4];

            Console.WriteLine($"RSA SSH Key generation with comment '{comment}' (no passphrase).");
            PickySshPrivateKey priv = PickySshPrivateKey.GenerateRsa(2048, "", comment);
            PickySshPublicKey pub = priv.ToPublicKey();

            Console.WriteLine($"Write to {privOutPath}");
            string privRepr = priv.ToRepr();
            File.WriteAllText(privOutPath, privRepr);

            Console.WriteLine($"Write to {pubOutPath}");
            string pubRepr = pub.ToRepr();
            File.WriteAllText(pubOutPath, pubRepr);

            break;
        }
    case "host-ssh-cert":
        {
            if (cliArgs.Length < 6)
            {
                Console.WriteLine("usage: PickyCLI host-ssh-cert <comment> <signer key path> <pub key path> <cert out path>");
                return;
            }

            string comment = cliArgs[2];
            string signerKeyPath = cliArgs[3];
            string pubKeyPath = cliArgs[4];
            string certOutPath = cliArgs[5];

            string pubKeyRepr = File.ReadAllText(pubKeyPath);
            PickySshPublicKey pubKey = PickySshPublicKey.Parse(pubKeyRepr);

            PickyPem privKeyPem = PickyPem.LoadFromFile(signerKeyPath);
            PickySshPrivateKey privKey;
            if (privKeyPem.ToLabel() == "OPENSSH PRIVATE KEY")
            {
                // Assume no passphrase
                privKey = PickySshPrivateKey.FromPem(privKeyPem, "");
            }
            else
            {
                PickyPrivateKey key = PickyPrivateKey.FromPem(privKeyPem);
                privKey = PickySshPrivateKey.FromPrivateKey(key);
            }

            PickySshTime validAfter = PickySshTime.Now();
            PickySshTime validBefore = PickySshTime.FromTimestamp(validAfter.Timestamp() + 999999);

            Console.WriteLine($"SSH Certificate generation with comment '{comment}'.");
            Console.WriteLine($"Valid after {validAfter.Year()}-{validAfter.Month()}-{validAfter.Day()}");
            Console.WriteLine($"Valid until {validBefore.Year()}-{validBefore.Month()}-{validBefore.Day()}");

            var builder = PickySshCert.Builder();
            builder.SetCertKeyType(PickySshCertKeyType.RsaSha2_256V01);
            builder.SetKey(pubKey);
            builder.SetCertType(PickySshCertType.Host);
            builder.SetValidAfter(validAfter);
            builder.SetValidBefore(validBefore);
            builder.SetSignatureKey(privKey);
            builder.SetComment(comment);
            PickySshCert cert = builder.Build();

            Console.WriteLine($"Write to {certOutPath}");
            string certRepr = cert.ToRepr();
            File.WriteAllText(certOutPath, certRepr);

            break;
        }
}

using NUnit.Framework;
using PCServ.Helpers;

namespace PCServTests
{
    [TestFixture]
    public class PasswordHelperTests
    {
        public class PasswordHashPair
        {
            public string Password { get; set; }
            public string Hash { get; set; }
        }

        public class PasswordSaltPair
        {
            public string Password { get; set; }
            public string Salt { get; set; }
        }

        // wygenerowane przy użyciu strony https://emn178.github.io/online-tools/sha256.html
        // zweryfikowane przy użyciu strony https://xorbin.com/tools/sha256-hash-calculator
        public static PasswordHashPair[] ValidPasswordHashList = new PasswordHashPair[]
        {
            new PasswordHashPair()
            {
                Password = "admin1", Hash= "25f43b1486ad95a1398e3eeb3d83bc4010015fcc9bedb35b432e00298d5021f7"
            },
            new PasswordHashPair()
            {
                Password = "T35tyJ3dn05tk0w3!!!", Hash= "0555ea5d7c43acfbad29f41d84dd9c304eb4482aa55275fcf7df1ebfa26db7b7"
            },
            new PasswordHashPair()
            {
                Password = "AndrzejuJakCiNaImie", Hash= "321f20a6946a5a4f9a710ddb33f1e4f9e9c04570ac852e8e10863bdf86d6b7ee"
            },
            new PasswordHashPair()
            {
                Password = "997DzwoniePoPolicje!", Hash= "b6360995bb46ed48001474188a1c960070129b0c9a5c894fd56b69ceb4b17bb8"
            },
            new PasswordHashPair()
            {
                Password = "JacekWgrywaNaProdukcjeWPiatek_:D", Hash= "a408051d4ad5ec8198dab80f7ba2bd8d19f781a8cb1e1578e87e9acb85806f4d"
            }
        };

        // pomieszane powyższe hashe i hasła aby nie pasowały do siebie
        public static PasswordHashPair[] InvalidPasswordHashList = new PasswordHashPair[]
        {
            new PasswordHashPair()
            {
                Password = "admin1", Hash= "0555ea5d7c43acfbad29f41d84dd9c304eb4482aa55275fcf7df1ebfa26db7b7"
            },
            new PasswordHashPair()
            {
                Password = "T35tyJ3dn05tk0w3", Hash= "321f20a6946a5a4f9a710ddb33f1e4f9e9c04570ac852e8e10863bdf86d6b7ee"
            },
            new PasswordHashPair()
            {
                Password = "AndrzejuJakCiNaImie", Hash= "b6360995bb46ed48001474188a1c960070129b0c9a5c894fd56b69ceb4b17bb8"
            },
            new PasswordHashPair()
            {
                Password = "997DzwoniePoPolicje", Hash= "a408051d4ad5ec8198dab80f7ba2bd8d19f781a8cb1e1578e87e9acb85806f4d"
            },
            new PasswordHashPair()
            {
                Password = "JacekWgrywaNaProdukcjeWPiatek_:D", Hash= "25f43b1486ad95a1398e3eeb3d83bc4010015fcc9bedb35b432e00298d5021f7"
            }
        };

        public static PasswordSaltPair[] PasswordWithSaltPairs = new PasswordSaltPair[]
        {
            new PasswordSaltPair()
            {
                Password = "pass1", Salt = "2wdscwef"
            },
            new PasswordSaltPair()
            {
                Password = "admin2!@!#3", Salt = "fef34fsdf"
            },
            new PasswordSaltPair()
            {
                Password = "haha3haha4123123!", Salt = "3rewds"
            },
            new PasswordSaltPair()
            {
                Password = "CoJestNo19191919%$#@", Salt = "32rewds"
            },
            new PasswordSaltPair()
            {
                Password = "#$@qweDS@!#2312dEDwe!", Salt = "23rewfsd"
            },
        };

        [Test]
        [TestCaseSource("ValidPasswordHashList")]
        public void Hash_HashWithoutSalt_CheckIfReturnsValidSha256Hash(PasswordHashPair passwordHashPair)
        {
            // Arrange
            string givenPassword = passwordHashPair.Password;
            string expectedHash = passwordHashPair.Hash;

            // Act
            string actualHash = PasswordHelper.Hash(givenPassword);

            // Assert
            Assert.AreEqual(expectedHash, actualHash);
        }

        [Test]
        [TestCaseSource("ValidPasswordHashList")]
        public void Verify_ValidPasswordAndHash_ReturnsTrue(PasswordHashPair passwordHashPair)
        {
            // Arrange
            string correctPassword = passwordHashPair.Password;
            string expectedHash = passwordHashPair.Hash;

            // Act
            bool result = PasswordHelper.Verify(correctPassword, expectedHash);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        [TestCaseSource("InvalidPasswordHashList")]
        public void Verify_InvalidPasswordAndHash_ReturnsFalse(PasswordHashPair passwordHashPair)
        {
            // Arrange
            string wrongPassword = passwordHashPair.Password;
            string expectedHash = passwordHashPair.Hash;

            // Act
            bool result = PasswordHelper.Verify(wrongPassword, expectedHash);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCaseSource("PasswordWithSaltPairs")]
        public void HashPasswordWithSalt_VerifyPasswordAndHash_ReturnsTrue(PasswordSaltPair passwordSaltPair)
        {
            // Arrange
            string password = passwordSaltPair.Password;
            string salt = passwordSaltPair.Salt;

            // Act
            string generatedHash = PasswordHelper.Hash(password, salt);
            bool result = PasswordHelper.Verify(password, generatedHash, salt);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
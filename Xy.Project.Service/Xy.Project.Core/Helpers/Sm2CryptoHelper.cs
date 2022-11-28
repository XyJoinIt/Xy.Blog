using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using System.Text;
using System.Text.RegularExpressions;

namespace Xy.Project.Core.Helpers
{
    public enum Mode
    {
        C1C2C3,
        C1C3C2
    }

    /// <summary>
    /// SM2国密加密解密
    /// </summary>
    public class Sm2CryptoHelper
    {
        // 公钥
        private byte[] _publicKey;
        // 私钥
        private byte[] _privateKey;
        // 
        private Mode _mode;
        // 
        private ICipherParameters _publicKeyParameters;
        // 
        private ICipherParameters _privateKeyParameters;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        /// <param name="mode"></param>
        public Sm2CryptoHelper(byte[] publicKey, byte[] privateKey, Mode mode = Mode.C1C2C3)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;
            _mode = mode;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        /// <param name="mode"></param>
        /// <param name="isPkcs8"></param>
        public Sm2CryptoHelper(string publicKey, string privateKey, Mode mode = Mode.C1C2C3, bool isPkcs8 = false)
        {
            if (!isPkcs8)
            {
                if (!string.IsNullOrWhiteSpace(publicKey))
                {
                    _publicKey = Decode(publicKey);
                }
                if (!string.IsNullOrWhiteSpace(privateKey))
                {
                    _privateKey = Decode(privateKey);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(publicKey))
                {
                    _publicKey = ((ECPublicKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey))).Q.GetEncoded();
                }
                if (!string.IsNullOrWhiteSpace(privateKey))
                {
                    _privateKey = ((ECPrivateKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey))).D.ToByteArray();
                }
            }
            _mode = mode;
        }
        /// <summary>
        /// 私钥参数
        /// </summary>
        private ICipherParameters PrivateKeyParameters
        {
            get
            {
                var r = _privateKeyParameters;
                if (r == null)
                    r = _privateKeyParameters = new ECPrivateKeyParameters(new BigInteger(1, _privateKey), new ECDomainParameters(GMNamedCurves.GetByName("SM2P256V1")));
                return r;
            }
        }
        /// <summary>
        /// 公钥参数
        /// </summary>
        private ICipherParameters PublicKeyParameters
        {
            get
            {
                var r = _publicKeyParameters;
                if (r == null)
                {
                    var x9ec = GMNamedCurves.GetByName("SM2P256V1");
                    r = _publicKeyParameters = new ECPublicKeyParameters(x9ec.Curve.DecodePoint(_publicKey), new ECDomainParameters(x9ec));
                }
                return r;
            }
        }
        /// <summary>
        /// 生成公私钥对
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        public static (string publicKey,string privateKey) GenerateKeyHex()
        {
            GenerateKey(out byte[] a, out byte[] b);
            string publicKey = Hex.ToHexString(a);
            string privateKey = Hex.ToHexString(b);
            return (publicKey,privateKey);
        }

        /// <summary>
        /// 生成公私钥对
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        public static void GenerateKey(out byte[] publicKey, out byte[] privateKey)
        {
            var g = new ECKeyPairGenerator();
            g.Init(new ECKeyGenerationParameters(new ECDomainParameters(GMNamedCurves.GetByName("SM2P256V1")), new SecureRandom()));
            var k = g.GenerateKeyPair();
            publicKey = ((ECPublicKeyParameters)k.Public).Q.GetEncoded();
            privateKey = ((ECPrivateKeyParameters)k.Private).D.ToByteArray();
        }

        /// <summary>
        /// 私钥解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] data)
        {
            if (_mode == Mode.C1C3C2)
                data = C132ToC123(data);
            var sm2 = new SM2Engine(new SM3Digest());
            sm2.Init(false, PrivateKeyParameters);
            return sm2.ProcessBlock(data, 0, data.Length);
        }

        /// <summary>
        /// 私钥解密
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string Decrypt(string msg)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(msg)));
        }

        /// <summary>
        /// 公钥加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] data)
        {
            var sm2 = new SM2Engine(new SM3Digest());
            sm2.Init(true, new ParametersWithRandom(PublicKeyParameters));
            data = sm2.ProcessBlock(data, 0, data.Length);
            if (_mode == Mode.C1C3C2)
                data = C123ToC132(data);
            return data;
        }

        /// <summary>
        /// 公钥加密
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string Encrypt(string msg)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(msg)));
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] Sign(byte[] msg, byte[] id = null)
        {
            var sm2 = new SM2Signer(new SM3Digest());
            ICipherParameters cp;
            if (id != null)
                cp = new ParametersWithID(new ParametersWithRandom(PrivateKeyParameters), id);
            else
                cp = new ParametersWithRandom(PrivateKeyParameters);
            sm2.Init(true, cp);
            sm2.BlockUpdate(msg, 0, msg.Length);
            return sm2.GenerateSignature();
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string Sign(string msg)
        {
            var sign = Sign(Encoding.UTF8.GetBytes(msg));
            return Encoding.UTF8.GetString(Base64.Encode(sign));
        }

        /// <summary>
        /// 验签
        /// </summary>
        /// <param name="msg">明文</param>
        /// <param name="signature">签名</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool VerifySign(byte[] msg, byte[] signature, byte[] id = null)
        {
            var sm2 = new SM2Signer(new SM3Digest());
            ICipherParameters cp;
            if (id != null)
                cp = new ParametersWithID(PublicKeyParameters, id);
            else
                cp = PublicKeyParameters;
            sm2.Init(false, cp);
            sm2.BlockUpdate(msg, 0, msg.Length);
            return sm2.VerifySignature(signature);
        }

        /// <summary>
        /// 验签
        /// </summary>
        /// <param name="msg">明文字符串</param>
        /// <param name="signature">签名</param>
        /// <returns></returns>
        public bool VerifySign(string msg, string signature)
        {
            return VerifySign(Encoding.UTF8.GetBytes(msg), Base64.Decode(signature));
        }

        /// <summary>
        /// C123ToC132
        /// </summary>
        /// <param name="c1c2c3"></param>
        /// <returns></returns>
        private byte[] C123ToC132(byte[] c1c2c3)
        {
            var gn = GMNamedCurves.GetByName("SM2P256V1");
            int c1Len = (gn.Curve.FieldSize + 7) / 8 * 2 + 1;
            int c3Len = 32;
            byte[] result = new byte[c1c2c3.Length];
            Array.Copy(c1c2c3, 0, result, 0, c1Len); //c1
            Array.Copy(c1c2c3, c1c2c3.Length - c3Len, result, c1Len, c3Len); //c3
            Array.Copy(c1c2c3, c1Len, result, c1Len + c3Len, c1c2c3.Length - c1Len - c3Len); //c2
            return result;
        }

        /// <summary>
        /// C132ToC123
        /// </summary>
        /// <param name="c1c3c2"></param>
        /// <returns></returns>
        private byte[] C132ToC123(byte[] c1c3c2)
        {
            var gn = GMNamedCurves.GetByName("SM2P256V1");
            int c1Len = (gn.Curve.FieldSize + 7) / 8 * 2 + 1;
            int c3Len = 32;
            byte[] result = new byte[c1c3c2.Length];
            Array.Copy(c1c3c2, 0, result, 0, c1Len); //c1: 0->65
            Array.Copy(c1c3c2, c1Len + c3Len, result, c1Len, c1c3c2.Length - c1Len - c3Len); //c2
            Array.Copy(c1c3c2, c1Len, result, c1c3c2.Length - c3Len, c3Len); //c3
            return result;
        }

        /// <summary>
        /// 转换公私钥
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private byte[] Decode(string key)
        {
            return Regex.IsMatch(key, "^[0-9a-f]+$", RegexOptions.IgnoreCase) ? Hex.Decode(key) : Convert.FromBase64String(key);
        }
    }
}

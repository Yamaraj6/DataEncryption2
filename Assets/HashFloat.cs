using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
[Serializable]
public class HashFloat : IEquatable<HashFloat>, IFormattable
{
    public float Value;
    private byte[] hash;

    private HashFloat()
    {
        Hash(this);
    }
    
    private HashFloat(float value)
    {
        this.Value = value;
        Hash(this);
    }

    private static void Hash(HashFloat hashFloat)
    {
        HashAlgorithm sha = new SHA1CryptoServiceProvider();
        hashFloat.hash = sha.ComputeHash(Encoding.UTF8.GetBytes(hashFloat.Value.ToString()));
    }

    private static void CheckCheat(HashFloat hashFloat)
    {
        if (!Compare(hashFloat))
        {
            Debug.LogError("Cheater!");
            hashFloat.Value = 0;
            Hash(hashFloat);
        }
    }

    private static bool Compare(HashFloat hashFloat)
    {
        HashAlgorithm sha = new SHA1CryptoServiceProvider();
        return hashFloat.hash.SequenceEqual(sha.ComputeHash(Encoding.UTF8.GetBytes(hashFloat.Value.ToString())));
    }

    #region operators, overrides, interface implementations

    public static implicit operator HashFloat(float value)
    {
        return new HashFloat(value);
    }

    public static implicit operator float(HashFloat hashFloat)
    {
        CheckCheat(hashFloat);
        Hash(hashFloat);
        return hashFloat.Value;
    }

    public bool Equals(HashFloat other)
    {
        return other.Value.Equals(Value);
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        return Value.ToString();
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    #endregion
}
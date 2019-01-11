using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

[Serializable]
public class HashInt : IEquatable<HashInt>
{
    public int Value;
    private byte[] hash;

    private HashInt()
    {
        Hash(this);
    }
    
    private HashInt(int value)
    {
        this.Value = value;
        Hash(this);
    }

    public void Set()
    {
        if (!IsCheated(this))
        {
            Value++;
        }

        Hash(this);
    }

    private static void Hash(HashInt hashInt)
    {
        var sha = new SHA256Managed();
        hashInt.hash = sha.ComputeHash(Encoding.UTF8.GetBytes(hashInt.Value.ToString()));
    }

    private static bool IsCheated(HashInt hashInt)
    {
        if (!Compare(hashInt))
        {
            Debug.LogError("Cheater detected!");
            hashInt.Value = 0;
            return true;
        }

        return false;
    }

    private static bool Compare(HashInt hashInt)
    {
        var sha = new SHA256Managed();
        return hashInt.hash.SequenceEqual(sha.ComputeHash(Encoding.UTF8.GetBytes(hashInt.Value.ToString())));
    }

    #region operators, overrides, interface implementations

    public static implicit operator HashInt(int value)
    {
        var hashInt = new HashInt(value);
        IsCheated(hashInt);
        Hash(hashInt);
        return hashInt;
    }

    public static implicit operator int(HashInt hashInt)
    {
        IsCheated(hashInt);
        Hash(hashInt);
        return hashInt.Value;
    }

    public bool Equals(HashInt other)
    {
        return other.Value.Equals(Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    #endregion
}
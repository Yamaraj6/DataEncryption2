using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Hashtest : MonoBehaviour
{
	public Text text;
	public HashInt ExampleHashInt = 5;
	public float a = 2;

//	private void Start()
//	{
//		var a = 2;
//		HashAlgorithm sha = new SHA1CryptoServiceProvider();
//		var hash1 = sha.ComputeHash(Encoding.UTF8.GetBytes(a.ToString()));
//		HashAlgorithm sha2 = new SHA1CryptoServiceProvider();
//		var hash2 = sha2.ComputeHash(Encoding.UTF8.GetBytes(a.ToString()));
//
//		var hash3 = sha2.ComputeHash(Encoding.UTF8.GetBytes(a.ToString()));
//
//		
//		Debug.Log(hash1.SequenceEqual(hash2));
//		Debug.Log(hash3.SequenceEqual(hash2));
//	}

	public void Increase()
	{
		a++;
		ExampleHashInt++;
		if (ExampleHashInt == 0)
		{
			text.text = "CHEATER!!!" + text.text;
		}
		else
		{
			text.text = ExampleHashInt.ToString();
		}

		text.text += " " + a;
	}

	public void Decrease()
	{
		ExampleHashInt--;
		if (ExampleHashInt == 0)
		{
			text.text = "CHEATER!!!\n" + ExampleHashInt.ToString();
		}
		else
		{
			text.text = ExampleHashInt.ToString();
		}
	}

	public void Set()
	{
		ExampleHashInt.Set();
		text.text = ExampleHashInt.ToString();
	}
}

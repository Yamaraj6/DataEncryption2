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
	public HashFloat ExampleHashFloat = 5;

	public void Increase()
	{
		ExampleHashFloat++;
		if (ExampleHashFloat == 0)
		{
			text.text = "CHEATER!!!" + text.text;
		}
		else
		{
			text.text = ExampleHashFloat.ToString();
		}
	}

	public void Decrease()
	{
		ExampleHashFloat--;
		if (ExampleHashFloat == 0)
		{
			text.text = "CHEATER!!!\n" + ExampleHashFloat.ToString();
		}
		else
		{
			text.text = ExampleHashFloat.ToString();
		}
	}
}

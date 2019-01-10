using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class CUtils : MonoBehaviour {

//	public static MethodInfo GetMethodInfo(string sOperator)
//	{
//		
//		MethodInfo oMethodInfo = null;
//		Type oType = typeof(CMethods);
//		MethodInfo[] aoInfo = oType.GetMethods();
//		foreach (MethodInfo oInfo in aoInfo)
//		{	
//			var oAttributes = oInfo.GetCustomAttributes(typeof(CMyAttribute), 
//				false);
//			if ((null == oAttributes) || (0 == oAttributes.Count()))
//			{
//				continue;
//			}
//			foreach (CMyAttribute oAttribute in oAttributes)
//			{
//				// interesuje nas pierwsza pasująca metoda
//				if (oAttribute.Method == sOperator)
//				{
//					oMethodInfo = oInfo;
//					break;
//				}
//			}
//		}
//		return oMethodInfo;
//	}
//
//	public ParameterInfo GetParameterInfo()
//	{
//		
//	}
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update ()
//	{
//	}
}

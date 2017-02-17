using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pictogram
{
	public int ID;

	// This will be replaced by the actual 2d image when available.
	public string symbol;
}

public class Scannable : MonoBehaviour {

	public List<Pictogram> theseSymbols;

}

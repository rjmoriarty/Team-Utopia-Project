using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pictogram
{
	public int id;
	public Material symbol;
	public string meaning;
}

public class Scannable : MonoBehaviour {

	public List<Pictogram> theseSymbols;

}

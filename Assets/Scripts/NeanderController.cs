using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class NeanderController : MonoBehaviour
{
    public static NeanderController INSTANCE;

    public List<string> _comandos = new List<string>();
    public List<int> _parametros = new List<int>();

    // Use this for initialization
    void Awake ()
    {
        INSTANCE = this;
	}
	
	void ReadTxtFile()
    {
        string myTxt = File.ReadAllText(Application.streamingAssetsPath + "/comandos.txt");

        string[] stringSeparators = new string[] { "\r\n" };

        StringReader reader = new StringReader(myTxt);
        string line = myTxt;
        string[] lineSplitEnters = line.Split(stringSeparators, System.StringSplitOptions.None);

        for(int i = 0; i < lineSplitEnters.Length; i++)
        {
            string currentLine = lineSplitEnters[i];
            string[] lineSplit = currentLine.Split(' ');
            string command = lineSplit[0];
            int parameter = int.Parse(lineSplit[1]);
            Debug.Log("comando - " + command + " / parametro memoria " + parameter.ToString());

            _comandos.Add(command);
            _parametros.Add(parameter);
        }
    }
}

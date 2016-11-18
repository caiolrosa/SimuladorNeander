using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class NeanderController : MonoBehaviour
{
    public static NeanderController INSTANCE;
    public Text PcText, Acumulador;

    public List<string> _comandos = new List<string>();
    public List<int> _parametros = new List<int>();
    public int[] memoria = new int[256];

    public int _Acumulador = 0;

    // Use this for initialization
    void Awake ()
    {
        INSTANCE = this;
	}

    void Start()
    {
        ReadTxtFile();
        UnidadeControle.LerInstrucao(_comandos[0], _parametros[0], _Acumulador);
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
            if (i < 127)
            {
                if (string.IsNullOrEmpty(currentLine))
                {
                    _comandos.Add("NOP");
                    _parametros.Add(0);
                    continue;
                }
                string[] lineSplit = currentLine.Split(' ');
                string command = lineSplit[0];
                int parameter = int.Parse(lineSplit[1]);
                Debug.Log("comando - " + command + " / parametro memoria " + parameter.ToString());

                _comandos.Add(command);
                _parametros.Add(parameter);
            }
            else
            {
                memoria[i] = int.Parse(currentLine);
            }
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class NeanderEditor {

    [MenuItem("Neander/read txt file")]
    public static void Test()
    {
        string myTxt = File.ReadAllText(Application.streamingAssetsPath + "/comandos.txt");

        string[] stringSeparators = new string[] { "\r\n" };

        StringReader reader = new StringReader(myTxt);
        string line = myTxt;
        string[] lineSplitEnters = line.Split(stringSeparators, System.StringSplitOptions.None);

        for (int i = 0; i < lineSplitEnters.Length; i++)
        {
            string currentLine = lineSplitEnters[i];
            if (i < 127)
            {
                //string[] lineSplit = currentLine.Split(' ');
                //string command = lineSplit[0];
                //int parameter = int.Parse(lineSplit[1]);
                //Debug.Log("comando - " + command + " / parametro memoria " + parameter.ToString());

                //_comandos.Add(command);
                //_parametros.Add(parameter);
            }
            else
            {
                Debug.Log(currentLine);
                //memoria[i] = int.Parse(currentLine);
            }
        }
    }
}

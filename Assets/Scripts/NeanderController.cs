using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class NeanderController : MonoBehaviour
{
    public static NeanderController INSTANCE;
    public Text Pc_Text, Acumulador_Text, BD_Text, RDM_Text, REM_Text, End_Text, RI_Text, MEM_Text, print_Text;
    public Toggle NegativeToggle, ZeroToggle;

    public List<int> _comandos = new List<int>();
    public List<int> _parametros = new List<int>();
    public int[] memoria = new int[256];

    public int _Acumulador = 0, pc = 1;

    public float TIMER_STEPS = 0.3f;

    // Use this for initialization
    void Awake ()
    {
        INSTANCE = this;
	}

    void Start()
    {
        ReadTxtFile();
    }

    public void tocarProxInstrucao()
    {
        Debug.Log("tocarProxInstrucao");
        UnidadeControle.LerInstrucao(_comandos[pc - 1], _parametros[pc - 1], _Acumulador);
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
                    _comandos.Add(0);
                    _parametros.Add(0);
                    continue;
                }
                string[] lineSplit = currentLine.Split(' ');
                int command = int.Parse(lineSplit[0]);
                int parameter = int.Parse(lineSplit[1]);
                //Debug.Log("comando - " + command + " / parametro memoria " + parameter.ToString());

                _comandos.Add(command);
                _parametros.Add(parameter);
            }
            else
            {
                if(string.IsNullOrEmpty(currentLine))
                {
                    memoria[i] = 0;
                    continue;
                }

                memoria[i] = int.Parse(currentLine);
            }
        }
    }
    
    /// <summary>
    /// decodifica o que vem do arquivo de texto
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public string decodificarInstrucao(int n)
    {
        string instrucao = "";

        switch(n)
        {
            case 0:
                instrucao = "NOP";
                break;
            case 1:
                instrucao = "ADD";
                break;
            case 2:
                instrucao = "STA";
                break;
            case 3:
                instrucao = "LDA";
                break;
            case 4:
                instrucao = "JUMP";
                break;
            case 5:
                instrucao = "JUMPN";
                break;
            case 6:
                instrucao = "JUMPZ";
                break;
            case 7:
                instrucao = "JUMPNZ";
                break;
            case 8:
                instrucao = "NOT";
                break;
            case 9:
                instrucao = "OR";
                break;
            case 10:
                instrucao = "AND";
                break;
            case 11:
                instrucao = "HLT";
                break;
        }

        RI_Text.text = "Registrador de instrução - " + n.ToString() + "\n Mnemônico - " + instrucao;

        return instrucao;
    }

    public void verificaEndereco(int end)
    {
        MEM_Text.text = "Endereço da memoria - " + end;
        REM_Text.text = End_Text.text = end.ToString();
        RDM_Text.text = memoria[end].ToString();
    }

    public void IncrementaPC()
    {
        int old = pc;
        pc++;
        print("incrementa PC: antigo valor " + old.ToString() + " -> novo valor " + pc.ToString());

        Pc_Text.text = pc.ToString();
    }

    public void IncrementaPC(int newValue)
    {
        print("PC recebe a posicao " + newValue);

        pc = newValue;

        Pc_Text.text = pc.ToString();
    }

    public void atualizaAcc(int newValue)
    {
        _Acumulador = newValue;
        Acumulador_Text.text = newValue.ToString();

        ZeroToggle.isOn = (_Acumulador == 0);
        NegativeToggle.isOn = (_Acumulador < 0);

        print("novo valor no acumulador: " + _Acumulador + "\n Flags N = " + NegativeToggle.isOn + " | Z = " + ZeroToggle.isOn);
    }

    public void armazenaValorNaMemoria(int end)
    {
        print("Armazena na memoria o valor do acumulador - " + NeanderController.INSTANCE._Acumulador + " - MEM(end) = " + end);
        memoria[end] = _Acumulador;
        RDM_Text.text = memoria[end].ToString();
    }

    public void print(string message, bool clear = false)
    {
        if(clear)
            print_Text.text = "Nova Instrução\n";

        print_Text.text += message + "\n";
        Debug.Log(message);
    }
}

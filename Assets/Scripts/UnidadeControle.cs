using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnidadeControle : MonoBehaviour {

    public static void LerInstrucao(string comando, int posMemoria, int ValorAcumulador)
    {
        string[] instrucaoLida;
        Instrucoes instrucoes = new Instrucoes();

        //try
        //{
        //    instrucaoLida = instrucao.Split(' ');
        //} catch(Exception error)
        //{
        //    throw new Exception("Não foi possível ler a instrução", error);
        //}

        switch (comando)
        {
            case "ADD":
                int tempValorAcumulador = instrucoes.ADD(posMemoria, ValorAcumulador);
                NeanderController.INSTANCE.Acumulador.text = tempValorAcumulador.ToString();
                break;

            case "STORE":
                instrucoes.STORE(posMemoria, ValorAcumulador);
                break;

            case "LOAD":
                instrucoes.LOAD(posMemoria);
                break;

            //case "JUMP":
            //    string valorMemoria = instrucoes.JUMP(posMemoria);
            //    LerInstrucao(comando, int.Parse(valorMemoria));
            //    break;

            //case "JUMPN":
            //    string valorMemoriaN = instrucoes.JUMPN(posMemoria, ValorAcumulador);
            //    LerInstrucao(comando, valorMemoriaN);
            //    break;

            //case "JUMPZ":
            //    string valorMemoriaZ = instrucoes.JUMPZ(posMemoria, ValorAcumulador);
            //    LerInstrucao(comando, posMemoria);
            //    break;

            //case "JUMPNZ":
            //    string valorMemoriaNZ = instrucoes.JUMPNZ(int.Parse(instrucaoLida[1]), ValorAcumulador);
            //    LerInstrucao(valorMemoriaNZ);
            //    break;

            case "NOT":
                instrucoes.NOT(ValorAcumulador);
                break;

            case "OR":
                instrucoes.OR(posMemoria, ValorAcumulador);
                break;

            case "AND":
                instrucoes.AND(posMemoria, ValorAcumulador);
                break;

            case "HALT":
                string halt = "Programa finalizado";
                break;

            case "NOP":
                break;

            default:
                break;
        }
    }
}

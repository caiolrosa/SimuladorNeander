using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnidadeControle : MonoBehaviour {

    public string stringAcumulador;
    public void LerInstrucao(string instrucao)
    {
        int ValorAcumulador = int.Parse(stringAcumulador);

        string[] instrucaoLida;
        Instrucoes instrucoes = new Instrucoes();

        try
        {
            instrucaoLida = instrucao.Split(' ');
        } catch(Exception error)
        {
            throw new Exception("Não foi possível ler a instrução", error);
        }

        switch (instrucaoLida[0])
        {
            case "ADD":
                ValorAcumulador = instrucoes.ADD(int.Parse(instrucaoLida[1]), ValorAcumulador);
                break;

            case "STORE":
                instrucoes.STORE(int.Parse(instrucaoLida[1]), ValorAcumulador);
                break;

            case "LOAD":
                instrucoes.LOAD(int.Parse(instrucaoLida[1]));
                break;

            case "JUMP":
                string valorMemoria = instrucoes.JUMP(int.Parse(instrucaoLida[1]));
                LerInstrucao(valorMemoria);
                break;

            case "JUMPN":
                string valorMemoriaN = instrucoes.JUMPN(int.Parse(instrucaoLida[1]), ValorAcumulador);
                LerInstrucao(valorMemoriaN);
                break;

            case "JUMPZ":
                string valorMemoriaZ = instrucoes.JUMPZ(int.Parse(instrucaoLida[1]), ValorAcumulador);
                LerInstrucao(valorMemoriaZ);
                break;

            case "JUMPNZ":
                string valorMemoriaNZ = instrucoes.JUMPNZ(int.Parse(instrucaoLida[1]), ValorAcumulador);
                LerInstrucao(valorMemoriaNZ);
                break;

            case "NOT":
                instrucoes.NOT(ValorAcumulador);
                break;

            case "OR":
                instrucoes.OR(int.Parse(instrucaoLida[1]), ValorAcumulador);
                break;

            case "AND":
                instrucoes.AND(int.Parse(instrucaoLida[1]), ValorAcumulador);
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnidadeControle : MonoBehaviour
{

    private static Instrucoes instrucoes = new Instrucoes();

    public static void LerInstrucao(int instrucao, int posMemoria, int ValorAcumulador)
    {
        string comando = NeanderController.INSTANCE.decodificarInstrucao(instrucao);

        NeanderController.INSTANCE.print("instrução = " + comando, true);
        switch (comando)
        {
            case "ADD": // 1 OK
                instrucoes.ADD(posMemoria, ValorAcumulador);
                break;

            case "STA": // 2 OK
                instrucoes.STA(posMemoria);
                break;

            case "LDA": // 3 OK
                (instrucoes.LDA(posMemoria);
                break;

            case "JUMP": // 4 OK
                instrucoes.JUMP(posMemoria);
                break;

            //case "JUMPN": // 5
            //    string valorMemoriaN = instrucoes.JUMPN(posMemoria, ValorAcumulador);
            //    LerInstrucao(comando, valorMemoriaN);
            //    break;

            //case "JUMPZ": // 6
            //    string valorMemoriaZ = instrucoes.JUMPZ(posMemoria, ValorAcumulador);
            //    LerInstrucao(comando, posMemoria);
            //    break;

            //case "JUMPNZ": // 7
            //    string valorMemoriaNZ = instrucoes.JUMPNZ(int.Parse(instrucaoLida[1]), ValorAcumulador);
            //    LerInstrucao(valorMemoriaNZ);
            //    break;

            case "NOT": // 8 OK
                instrucoes.NOT(ValorAcumulador);
                break;

            case "OR": // 9 OK
                instrucoes.OR(posMemoria, ValorAcumulador);
                break;

            case "AND": // 10 OK
                instrucoes.AND(posMemoria, ValorAcumulador);
                break;

            case "HLT": // 11
                NeanderController.INSTANCE.IncrementaPC();

                NeanderController.INSTANCE.print("Programa finalizado");
                break;

            case "NOP": // 0 OK
                NeanderController.INSTANCE.IncrementaPC();
                break;

            default:
                break;
        }
    }
}

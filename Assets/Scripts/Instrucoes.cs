using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucoes : MonoBehaviour {
	[SerializableField]
	private int[] memoria;
	public Instrucoes ()
	{
		memoria = new string[256]();
	}

	// Funcao de para instrucao: ADD
	public int ADD(int end, int acumulador) {
		int valorMemoria;

		try {
			// Pegando valor da memoria pos = posMemoria --- valor
			valorMemoria = int.Parse(memoria[end]);
		} catch(Exception error) {
			throw new KeyNotFoundException();
		}

		// Somando valor da memoria com o valor do acumulador
		int resultado = valorMemoria + acumulador;

		return resultado;
	}

	public void STORE(int end, int valor) {
		try {
			memoria[end] = valor.ToString();
		} catch(Exception error) {
			throw new Exception("Nao foi possivel inserir na posicao desejada. \n" + error);
		}
	}

	public int LOAD(int end) {
		int valor;

		try {
			valor = int.Parse(memoria[end]);
		} catch(Exception error) {
			throw new Exception("Nao foi possivel carregar da posicao desejada. \n" + error);
		}

		return valor;
	}

    public int NOT(int acumulador)
    {
        return ~acumulador;
    }

    public string JUMP(int end)
    {
        return memoria[end];
    }

    // OR e AND ainda nao estao 100% 
    public void OR(int end, int acumulador)
    {
        return int.Parse(memoria[end]) | acumulador;
    }

    public void AND(int end, int acumulador)
    {
        return int.Parse(memoria[end]) & acumulador;
    }
}

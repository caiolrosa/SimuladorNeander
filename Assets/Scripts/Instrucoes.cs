using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucoes : MonoBehaviour {
	[SerializableField]
	private int[] memoria;
	public Instrucoes ()
	{
		memoria = new int[256]();
	}

	// Funcao de para instrucao: ADD
	public int ADD(int posMemoria, int acumulador) {
		int valorMemoria;

		try {
			// Pegando valor da memoria pos = posMemoria --- valor
			valorMemoria = memoria[posMemoria];
		} catch(Exception error) {
			throw new KeyNotFoundException();
		}

		// Somando valor da memoria com o valor do acumulador
		int resultado = valorMemoria + acumulador;

		return resultado;
	}

	public void STORE(int posMemoria, int valor) {
		try {
			memoria[posMemoria] = valor;
		} catch(Exception error) {
			throw new Exception("Nao foi possivel inserir na posicao desejada. \n" + error);
		}
	}

	public void LOAD(int posMemoria) {
		int valor;

		try {
			valor = memoria[posMemoria];
		} catch(Exception error) {
			throw new Exception("Nao foi possivel carregar da posicao desejada. \n" + error);
		}

		return valor;
	}

	/*public void OR(int posMemoria, int acumulador) {
		int valorMemoria;

		try {
			valorMemoria = memoria[posMemoria];
		} catch(Exception error) {
			throw new Exception("Nao foi possivel carregar da posicao desejada. \n" + error);
		}

		if (valorMemoria == 1 || acumulador == 1) {
			return 1;
		} 

		return 0;
	}

	public void AND(int posMemoria, int acumulador) {
		int valorMemoria;

		try {
			valorMemoria = memoria[posMemoria];
		} catch(Exception error) {
			throw new Exception("Nao foi possivel carregar da posicao desejada. \n" + error);
		}

		int resultado = valorMemoria && acumulador;

		return resultado;
	}*/
}
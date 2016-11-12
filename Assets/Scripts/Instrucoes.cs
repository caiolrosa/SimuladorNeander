using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucoes : MonoBehaviour
{
	private string[] memoria;

	public Instrucoes ()
	{
		memoria = new string[256];
	}

	// Funcao de para instrucao: ADD
	public int ADD(int end, int valorAcumulador) {
        int valorMemoria;
		try {
			// Pegando valor da memoria pos = posMemoria --- valor
			valorMemoria = NeanderController.INSTANCE.memoria[end];
		} catch(Exception error) {
            throw new Exception("Não foi possível pegar o conteudo do endereço de memória", error);
        }

		// Somando valor da memoria com o valor do acumulador
		int resultado = valorMemoria + valorAcumulador;

		return resultado;
	}

	public void STORE(int end, int valorAcumulador) {
		try {
			memoria[end] = valorAcumulador.ToString();
		} catch(Exception error) {
            throw new Exception("Não foi possível pegar o conteudo do endereço de memória", error);
        }
	}

	public int LOAD(int end) {
		int valor;

		try {
			valor = int.Parse(memoria[end]);
		} catch(Exception error) {
            throw new Exception("Não foi possível pegar o conteudo do endereço de memória", error);
        }

		return valor;
	}

    public string JUMP(int end)
    {
        string conteudoMemoria;

        try
        {
            conteudoMemoria = memoria[end];
        }
        catch (Exception error)
        {
            throw new Exception("Não foi possível pegar o conteudo do endereço de memória", error);
        }

        return memoria[end];
    }

    public string JUMPN(int end, int valorAcumulador)
    {
        string conteudoMemoria;

        if (valorAcumulador < 0)
        {
            try
            {
                conteudoMemoria = memoria[end];
            } catch(Exception error)
            {
                throw new Exception("Não foi possível pegar o conteudo do endereço de memória", error);
            }

            return conteudoMemoria;
        } else
        {
            return null;
        }
        
    }

    public string JUMPZ(int end, int valorAcumulador)
    {
        string conteudoMemoria;

        if (valorAcumulador == 0)
        {
            try
            {
                conteudoMemoria = memoria[end];
            }
            catch (Exception error)
            {
                throw new Exception("Não foi possível pegar o conteudo do endereço de memória", error);
            }

            return conteudoMemoria;
        } else
        {
            return null;
        }
    }

    public string JUMPNZ(int end, int valorAcumulador)
    {
        string conteudoMemoria;

        if (valorAcumulador != 0)
        {
            try
            {
                conteudoMemoria = memoria[end];
            }
            catch (Exception error)
            {
                throw new Exception("Não foi possível pegar o conteudo do endereço de memória", error);
            }

            return conteudoMemoria;
        }
        else
        {
            return null;
        }
    }

    public void NOT(int valorAcumulador)
    {
        int notAcumulador = valorAcumulador;
        string binaryNot = Convert.ToString(notAcumulador, 2);
    }

    public void OR(int end, int valorAcumulador)
    {
        int orAcumulador = valorAcumulador | end;
        string binaryNot = Convert.ToString(orAcumulador, 2);
    }

    public void AND(int end, int valorAcumulador)
    {
        int andAcumulador = valorAcumulador & end;
        string binaryNot = Convert.ToString(andAcumulador, 2);
    }
}

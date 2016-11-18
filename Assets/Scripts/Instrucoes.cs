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
        //BUSCA
        Debug.Log("RI pega o valor do PC da memoria");
        Debug.Log("end pega a posicao da memoria");
        //EXECUTA
        valorMemoria = NeanderController.INSTANCE.memoria[end];
        
        Debug.Log("incrementa PC");
        
		// Somando valor da memoria com o valor do acumulador
		int resultado = valorMemoria + valorAcumulador;

        Debug.Log("Acumulador = Acumulador + MEM(end)");

        return resultado;
	}

	public void STA(int end, int valorAcumulador) {
        //Busca
        Debug.Log("RI = valor do PC na memoria");

        //Executa
        Debug.Log("end = " + memoria[end].ToString());
        Debug.Log("incrementa PC");
        memoria[end] = valorAcumulador.ToString();
        Debug.Log("Armazena na memoria o valor do acumulador - MEM(end) = " + valorAcumulador);
	}

	public int LDA(int end) {
		int valor;

        Debug.Log("RI pega o valor do PC da memoria");
        Debug.Log("end pega a posicao da memoria");
        Debug.Log("incrementa PC");

        valor = int.Parse(memoria[end]);
        Debug.Log("acumulador recebe o valor que estava na posicao da memoria " + end);

		return valor;
	}

    public string JUMP(int end)
    {
        string conteudoMemoria;

        Debug.Log("RI pega o valor do PC da memoria");
        Debug.Log("end pega a posicao da memoria");
        Debug.Log("PC recebe valor " + end);

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
        Debug.Log("RI pega o valor do PC da memoria");
        Debug.Log("incrementa PC");

        int notAcumulador = valorAcumulador;
        string binaryNot = Convert.ToString(notAcumulador, 2);
        Debug.Log("Acumulador recebe valor NOT(AC)");
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

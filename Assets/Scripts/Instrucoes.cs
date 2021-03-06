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
	public IEnumerator ADD(int end, int valorAcumulador) {
        NeanderController.usingStep = true;

        int valorMemoria;

        NeanderController.INSTANCE.verificaEndereco(end);
        NeanderController.INSTANCE.print("end pega a posicao da memoria");

        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        //EXECUTA
        valorMemoria = NeanderController.INSTANCE.memoria[end];

        NeanderController.INSTANCE.IncrementaPC();

        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        // Somando valor da memoria com o valor do acumulador
        int resultado = valorMemoria + valorAcumulador;

        NeanderController.INSTANCE.print("Acumulador = " + valorAcumulador.ToString() + " + " + valorMemoria.ToString());

        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);
        NeanderController.INSTANCE.atualizaAcc(resultado);
        NeanderController.usingStep = false;
    }

	public IEnumerator STA(int end) {
        //Busca
        //NeanderController.INSTANCE.print("RI carrega a instru�ai STA");
        NeanderController.usingStep = true;
        //Executa
        //NeanderController.INSTANCE.verificaEndereco(end);

        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        NeanderController.INSTANCE.armazenaValorNaMemoria(end);

        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        NeanderController.INSTANCE.IncrementaPC();
        NeanderController.usingStep = false;
    }

	public IEnumerator LDA(int end) {
        NeanderController.usingStep = true;
        int valor;
        NeanderController.INSTANCE.print("end pega a posicao da memoria");
        NeanderController.INSTANCE.verificaEndereco(end);
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        NeanderController.INSTANCE.IncrementaPC();
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        valor = NeanderController.INSTANCE.memoria[end];
        Debug.Log("valor " + valor);
        NeanderController.INSTANCE.print("acumulador recebe o valor que estava na posicao da memoria " + end);
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        NeanderController.INSTANCE.atualizaAcc(valor);
        NeanderController.usingStep = false;
    }

    public void JUMP(int end)
    {
        NeanderController.INSTANCE.IncrementaPC(end);
    }

    public void JUMPN(int end, int valorAcumulador)
    {
        if(NeanderController.INSTANCE.NegativeToggle.isOn)
        {
            NeanderController.INSTANCE.IncrementaPC(end);
            return;
        }
        NeanderController.INSTANCE.IncrementaPC();
    }

    public void JUMPZ(int end, int valorAcumulador)
    {
        if (NeanderController.INSTANCE.ZeroToggle.isOn)
        {
            NeanderController.INSTANCE.IncrementaPC(end);
            return;
        }
        NeanderController.INSTANCE.IncrementaPC();

    }

    //public string JUMPNZ(int end, int valorAcumulador)
    //{
    //    string conteudoMemoria;

    //    if (valorAcumulador != 0)
    //    {
    //        try
    //        {
    //            conteudoMemoria = memoria[end];
    //        }
    //        catch (Exception error)
    //        {
    //            throw new Exception("N�o foi poss�vel pegar o conteudo do endere�o de mem�ria", error);
    //        }

    //        return conteudoMemoria;
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}

    public IEnumerator NOT(int valorAcumulador)
    {
        NeanderController.usingStep = true;
        NeanderController.INSTANCE.IncrementaPC();
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        int notAcumulador = ~valorAcumulador;

        NeanderController.INSTANCE.print("Acumulador recebe valor NOT("+ valorAcumulador + ")");

        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);
        NeanderController.INSTANCE.atualizaAcc(notAcumulador);
        NeanderController.usingStep = false;
    }

    public IEnumerator OR(int end, int valorAcumulador)
    {
        NeanderController.usingStep = true;
        NeanderController.INSTANCE.IncrementaPC();
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        NeanderController.INSTANCE.verificaEndereco(end);

        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        int orAcumulador = valorAcumulador | NeanderController.INSTANCE.memoria[end];

        NeanderController.INSTANCE.print("Bits do valor no acumulador = " + Convert.ToString(valorAcumulador, 2));
        NeanderController.INSTANCE.print("Bits do valor na memoria = " + Convert.ToString(NeanderController.INSTANCE.memoria[end], 2));
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);
        NeanderController.INSTANCE.print("resp do valor no acumulador = " + Convert.ToString(orAcumulador, 2));
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        NeanderController.INSTANCE.atualizaAcc(orAcumulador);
        NeanderController.usingStep = false;
    }

    public IEnumerator AND(int end, int valorAcumulador)
    {
        NeanderController.usingStep = true;
        NeanderController.INSTANCE.IncrementaPC();
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        NeanderController.INSTANCE.verificaEndereco(end);
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);
        int orAcumulador = valorAcumulador & NeanderController.INSTANCE.memoria[end];

        NeanderController.INSTANCE.print("Bits do valor no acumulador = " + Convert.ToString(valorAcumulador, 2));
        NeanderController.INSTANCE.print("Bits do valor na memoria = " + Convert.ToString(NeanderController.INSTANCE.memoria[end], 2));
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);
        NeanderController.INSTANCE.print("resp do valor no acumulador = " + Convert.ToString(orAcumulador, 2));
        yield return new WaitForSeconds(NeanderController.INSTANCE.TIMER_STEPS);

        NeanderController.INSTANCE.atualizaAcc(orAcumulador);
        NeanderController.usingStep = false;
    }
}

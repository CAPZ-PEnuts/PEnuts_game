using System.Collections;
using System.Threading;
using System; 
using System.Collections.Generic;
using UnityEngine;

public class porte : MonoBehaviour {

    private Stack<boutton> buttons;
    public boutton[] mybut;
    public int nbelmt;

    public porte()
    {
        mybut = new boutton[nbelmt];
        buttons = new Stack<boutton>(); 
    }

   void Start()
    {
        Thread.Sleep(3);
        for (int i = nbelmt - 1; i >= 0; i--)
            buttons.Push(mybut[i]);
    }

    public void activebutton (boutton bouton)
    {
        Console.WriteLine("Button presse");
        if (bouton == buttons.Peek())
        {
            buttons.Pop();
            destroyit(); 
        }
    }

    private void destroyit()
    {
        if (buttons.Peek().place == nbelmt - 1)
            Destroy(this.gameObject); 
    }

}

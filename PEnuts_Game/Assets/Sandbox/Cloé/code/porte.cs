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
        
    }

    void Start()
    {
        mybut = new boutton[nbelmt];
        buttons = new Stack<boutton>();
        Thread.Sleep(3);
        foreach (boutton but in mybut)
            buttons.Push(but);
    }
    

    
   /*void Start()
    {
        
    }*/

    public void activebutton (boutton bouton)
    {
        Debug.Log("Prout");
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

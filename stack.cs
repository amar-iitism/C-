using System;
using System.Collections.Generic;

public class MyStack {
    private List<int> elements = new List<int>();
    
    public void Push(int item) {
        elements.Add(item);
    }
    
    public int Pop() {
        if(elements.count == 0 ){
            throw new InvalidOperationException("Stack is Empty");
        }
        int top = elements[elemetns.Count - 1];
        elements.RemoveAt(elements.Count - 1);
        return top;
    }
    
    public int peek () {
         if(elements.Count == 0 ){
            throw new InvalidOperationException("Stack is Empty");
        }
        return elements[elements.Count - 1];
    }
    
    
}

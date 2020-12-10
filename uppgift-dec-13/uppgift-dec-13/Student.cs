using System;
using System.Collections.Generic;
using System.Text;

namespace uppgift_dec_13
{
    
    class Student
    {
        public String Status { get; set; }
        private Memento memento;

        public Student()
        {
            this.Status = "Empty";
            this.memento = new Memento(this.Status);
        }

        public void Save()
        {   
            
            this.memento.mementoStack.Push(this.Status);
        }

        public void Revert()
        {
            this.memento.mementoStackRedo.Push(this.Status);
            this.Status = this.memento.mementoStack.Pop();           
        }

        public void Redo()
        {
            this.memento.mementoStack.Push(this.Status);
            this.Status = this.memento.mementoStackRedo.Pop();                     
        }
    }

    class Memento
    {
        public readonly string status;
        public Stack<string> mementoStack = new Stack<string>();
        public Stack<string> mementoStackRedo = new Stack<string>();
        public Memento(String status)
        {
            this.status = status;
            mementoStack.Push(status);                   
        }
        public Memento(string status, string old)
        {
            this.status = status;
            mementoStackRedo.Push(status);
        }
    }
}


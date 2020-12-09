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

        public void Save(string update)
        {
            this.Status = update;
            this.memento.mementoStack.Push(update);
        }

        public void Revert()
        {
            this.Status = this.memento.mementoStack.Pop();
            //this.Status = this.memento.status;
        }
    }

    class Memento
    {
        public readonly string status;
        public Stack<string> mementoStack = new Stack<string>();
        public Memento(String status)
        {
            this.status = status;
            mementoStack.Push(status);                   
        }
    }
}


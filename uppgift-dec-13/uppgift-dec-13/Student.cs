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
            this.Status = "not right";
            this.memento = new Memento(this.Status);
        }

        public void Save(string update)
        {
            this.Status = update;
            this.memento = new Memento(this.Status);
        }

        //public void StartAdmitionProcess()
        //{
        //    this.Status = "Admited";
        //}

        public void Revert()
        {
            this.Status = this.memento.status;
        }
    }

    class Memento
    {
        public readonly string status;

        public Memento(String status)
        {
            this.status = status;
        }
    }
}


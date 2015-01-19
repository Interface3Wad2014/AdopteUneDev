using AdopteUneDev.WADAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopteUneDev.Areas.Boutique.Models
{
    public class Ligne
    {
        private Developer _zeDave;
        private int _qte;
        private int _tarif;

        public int Qte
        {
            get { return _qte; }
            set { _qte = value; }
        }

        public float Cout
        {
            get { return FnCout(); }
        }

       

        public int Tarif
        {
            get { return _tarif; }
            set { _tarif = value; }
        }


        public Developer ZeDave
        {
            get { return _zeDave; }
            set { _zeDave = value; }
        }

        private float FnCout()
        {
            return Tarif * Qte;
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUczniowie.Baza_danych.Model
{
    class Uczen
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int RokUrodzenia { get; set; }

        public int KlasaId { get; set; }
        public Klasa Klasa { get; set; }
    }
}

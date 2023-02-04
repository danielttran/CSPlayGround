using System;
using System.Collections.Generic;

namespace GrantHornerReading
{

    public class MainProgram
    {

        static void Main(string[] args)
        {
            
            var Gh = new GrantHornerSystem(10);
            Gh.PrintChapters(36524*2);

        }
    }
}
﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Teste.Comum.Inicializador
{
    [TestFixture]
    public abstract class TesteBase
    {

        [SetUp]
        public abstract void Initialize();
    }
}

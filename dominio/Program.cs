﻿using appRegistroEmpresaDomiciliaria.dominio;
using System;
using System.Windows.Forms;

namespace appRegistroEmpresaDomiciliaria {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace WTG.SMTP.DEMO
{
    [RunInstaller(true)]
    public partial class SMTPServiceInstaller : System.Configuration.Install.Installer
    {
        public SMTPServiceInstaller()
        {
            InitializeComponent();
        }
    }
}

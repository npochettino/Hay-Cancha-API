using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDatos.ClasesComplementarias;

namespace BibliotecaDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            PushNotification.SendPersonalPush("reservation","HayCancha ha respondido", "APA91bEUE5sNlWgxSG5vEidYN35Wj_tsA4vXcGFBFDzrD1mU6KuQQFGAopj7AMnFBOMWcNY3ABuCLir336Xw_VXjA3Chj2T4gZXWDBqDxanPWrR_ED6DmTteq3hQnAD3m818WBL_fNHA");
        }
    }
}

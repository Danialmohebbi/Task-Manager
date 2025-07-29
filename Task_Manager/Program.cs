using System;

namespace Task_Manager;

using System;
using Task_Manager.App.Extensions;
using Task_Manager.App.Services;
using Task_Manager.Data;
using Task_Manager.Data.Repositories;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Database database = Database.GetInstance();
        Application.Run(new Login());
    }
}

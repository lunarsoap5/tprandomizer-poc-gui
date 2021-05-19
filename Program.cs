using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace TPRandomizer

{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Singleton.getInstance().Checks.InitializeChecks();
            foreach (string file in System.IO.Directory.GetFiles("./Randomizer/Checks/", "*", SearchOption.AllDirectories))
            {
                string contents = File.ReadAllText(file);
                string fileName = Path.GetFileNameWithoutExtension(file);
                Singleton.getInstance().Checks.CheckDict[fileName] = JsonConvert.DeserializeObject<Check>(contents);
                Check currentCheck = Singleton.getInstance().Checks.CheckDict[fileName];
                currentCheck.requirements = Regex.Replace(currentCheck.requirements, @"\bLogic\b", "LogicFunctions");
                Singleton.getInstance().Checks.CheckDict[fileName] = currentCheck;
                Console.WriteLine("Check File Loaded " + fileName);
            }
            Application.Run(new Form1());
        }
    }
}

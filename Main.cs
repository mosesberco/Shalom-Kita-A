using System;
using System.Windows.Forms;

namespace final_project
{
    static class main
    {
        [STAThread]
        public static void  Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var new_form = new EnglishGame2.GameForm();
            //var hebrew_form = new Hebrew_Memory_Matching_Game.
            Application.Run(new_form);
        }
    }
}

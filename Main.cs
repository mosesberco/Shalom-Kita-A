using System;
using System.Windows.Forms;

namespace final_project
{
    static class main
    {
        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var new_form = new Game_Udi();
            var x =new DatabaseOperations();
            var store_form = new StoreForm();
            //var hebrew_form = new Hebrew_Memory_Matching_Game.
            //Application.Run(store_form);
            //var game = new EnsglishBuildWordsGameMenu();
            //var form = new Register();
            //Application.Run(new_form);
        }
    }
}

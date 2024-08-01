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
            var DB =new Database();
            var store_form = new StoreForm(206872871, DB);
            var hebrew_game = new Hebrew_Etai();
            //new_form.ShowDialog();
            //var hebrew_form = new Hebrew_Memory_Matching_Game.
            Application.Run(hebrew_game);
            DB.Dispose();
            //var game = new EnsglishBuildWordsGameMenu();
            //var form = new Register();
            //Application.Run(new_form);
        }
    }
}

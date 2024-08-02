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
            var hebrew_game = new Register();
            //new_form.ShowDialog();
            //var hebrew_form = new Hebrew_Memory_Matching_Game.
            Application.Run(hebrew_game);
            DB.Dispose();
            //var game = new EnsglishBuildWordsGameMenu();
<<<<<<< HEAD
            //var form = new Register();
            //Application.Run(new_form);
=======
            //Application.Run(new_form);
            var game_Diana = new GameScreen();
            Application.Run(new GameScreen());
>>>>>>> origin/dianaMerge
        }
    }
}

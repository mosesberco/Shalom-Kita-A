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
            //var new_form = new Game_Udi();
            var DB =new Database();
            //var store_form = new StoreForm(206872871, DB);
            //var hebrew_game = new Register();
            DB.RegisterUser("moses", "bro", "1234", "m@g.c", "Male");
            DB.SetBalance(1234, 1000);
            User user = new User("moses", "bro", "1234" , "m@g.c", "Male", 10_000);
            ///var store = new StoreForm(user);
            //var new_form = new Game_Udi(user);
            ///var new_form = new Menu(user);
            //Application.Run(store);
            //new_form.ShowDialog();
            //var hebrew_form = new Hebrew_Memory_Matching_Game.
            //Application.Run(hebrew_game);
            DB.Dispose();
            //Application.Run(new GameScreen(user));
            //Application.Run(new Login());
            //Application.Run(new HebrewGame_sapir(user));
            //Application.Run(new Hebrew_Etai(user));
            //Application.Run(new EnglishMemoryGameMenu(user));
            //Application.Run(new EnglishBuildWordsGameMenu(user));
            //Application.Run(new Menu(user));
            //Application.Run(new UserInterface(DB,1));


        }
    }
}

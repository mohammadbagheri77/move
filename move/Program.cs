using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace move
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            string downloadString , str ;

            List<class_move> list_move = new List<class_move>();
            class_get_move get_sring = new class_get_move();
          //  StringBuilder str = new StringBuilder();

            /////////////////////////////////////////////////////////

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            downloadString = client.DownloadString("https://www.uptvs.com");

            str = get_sring.GetStringBetween(downloadString, "<div class=\"tabcontents\">", "</div>");
           

            //  Console.WriteLine(str);

           List<string> all = get_sring.List_file_move(str,"<li>","</li>");

            for (int ii = 0; ii < all.Count; ii++)
            {
                class_move Move = new class_move();
                Move.move_link = "https://www.uptvs.com";
                Move.move_name = get_sring.GetStringBetween(all[ii], "<a title=\"", "\" href");
                Move.move_token = get_sring.GetStringBetween(all[ii], "href=\"" , "\" >");
                list_move.Add(Move);
            }  
          

           for (int i=0; i <list_move.Count; i++)
            {
                Console.WriteLine($"{list_move[i].move_link} \n {list_move[i].move_name } \n {list_move[i].move_token }");
            }
           

           
            Console.ReadLine();
        }

    }

}

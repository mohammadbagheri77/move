using Newtonsoft.Json;
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

            List<class_move> list_move;
                //= new List<class_move>();
            class_get_move get_sring = new class_get_move();


            /////////////////////////////////////////////////////////

           cash saveCash = new cash("Latest_Movies", "move");
            string JsonFromCash = saveCash.TextFromFile();
            
            if (string.IsNullOrEmpty(JsonFromCash))

            {
                list_move = new List<class_move>();
            }
            else
            {
                list_move = JsonConvert.DeserializeObject<List<class_move>>(JsonFromCash);
            }
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            downloadString = client.DownloadString("https://www.uptvs.com");

            str = get_sring.GetStringBetween(downloadString, "<div class=\"tabcontents\">", "</div>");
         // str = get_sring.GetStringBetween(downloadString, "<div class=\"footer-left-side-second\">", "</div>");
           
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
                Console.WriteLine($"{list_move[i].move_link} \n {list_move[i].move_name } \n {list_move[i].move_token }\n===================================================");
            }

            int iii = SaveCash(list_move);
            switch (iii)
            {
                case 1:
                    Console.WriteLine("Cash Saved Done!");
                    break;
                case -1:
                    Console.WriteLine("Failed !");
                    break;
                case -2:
                    Console.WriteLine("Failed !");
                    break;
                default:
                    Console.WriteLine("Nothing!");
                    break;
            }

            Console.ReadLine();
        }
        public static int SaveCash(List<class_move> TOCASH)
        {
            string JsonSerialized = JsonConvert.SerializeObject(TOCASH);
            cash saveCash = new cash("Latest_Movies", "move");
            int res = 0;
            try
            {
                res = saveCash.Write_ToFile(JsonSerialized, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }
    }

}

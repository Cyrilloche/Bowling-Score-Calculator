namespace BowlingScoreCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* TO DO
             * Dessiner un affichage pour voir les différents score
             * Définir un nombre de lancée maximum (condition de fin) 
             * 2 lancés par tour et par joueur
             * Créer une liste des joueurs pour avoir leur nom afficher
             * 
             * */

            /* Liste des fonctions à créer
             * Fonction aléatoire, pour simuler les lancées lors du débogage
             * */

            //CreatePlayers();
            //Console.ReadLine();
            //Shot();

            Play(CreatePlayers());

            }

        public static void ShowScore(string nameOfPlayer, int firstShot, int secondShot, int scoreOfPlayer)
        {
            Console.Write("   ----------------------------------------------");
            Console.Write("   |          Calculateur de Score de Bowling        |");
            Console.Write("   ----------------------------------------------");

            Console.Write("\n   | Nom Joueur: " + nameOfPlayer);
            Console.Write("   ----------------------------------------------");

            // En-têtes du tableau
            Console.Write("\n   | Manche | 1 |  2   |  3   |  4   |  5   |  6   |  7   |  8   |  9   |  10  |");
            Console.Write("\n   ----------------------------------------------");

            // Scores pour le premier lancer
            Console.Write("\n   |Lancer 1|");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("   |   ");
            }

            Console.Write("    |");
            Console.Write("\n   ----------------------------------------------");

            // Scores pour le deuxième lancer
            Console.Write("\n   |Lancer 2|");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("   |   ");
            }

            Console.Write("    |");
            Console.Write("\n   ----------------------------------------------");

            // Total
            Console.Write("\n   |Total   |");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("   |   ");
            }

            Console.Write("    |");
            Console.Write("\n   ----------------------------------------------");

            Console.ReadLine();
        }
    

        public static Dictionary<string, int> CreatePlayers()
        {
            Dictionary<string, int> listOfPlayers = new Dictionary<string, int>();
            Console.WriteLine("Bienvenue au Bowling de MNS\nCombien de joueurs êtes vous ?");
            int numbersOfPlayers = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Super ! Rentrés tour à tour vos noms dans l'ordinateur");
            for (int i = 0; i < numbersOfPlayers; i++)
            {
                Console.Write("Nom : ");
                string nameOfPlayer = Console.ReadLine();
                listOfPlayers.Add(nameOfPlayer, 0);
                Console.WriteLine("Bienvenue " + nameOfPlayer);
            }
            Console.WriteLine("\nAppuyer sur entrée pour commencer la partie");
            Console.ReadLine();
            return listOfPlayers;
        }

        public static bool IsSpare(int firstShot, int secondShot)
        {
            if (firstShot + secondShot == 10)
                return true;
            return false;
        }

        public static bool IsStrike(int firstShot)
        {
            if (firstShot == 10)
                return true;
            return false;
        }

        public static int Shot()
        {
            Random random = new Random();
            int shot = random.Next(0, 10);
            if (shot == 1)
                Console.WriteLine("Une seule quille est tombée"); 
            else if(shot ==0)
                Console.WriteLine("Aucune quille n'est tombée...");
            else
                Console.WriteLine(shot + " quilles sont tombés");
            return shot;
        }

        public static int CalculateScore(int firstShot, int secondShot, Dictionary<string,int> listOfPlayers, string nameOfPlayers)
        {
            int previousScore = listOfPlayers[nameOfPlayers];
            int score = 0;

            if (IsStrike(firstShot)){
                score = 10 + firstShot + secondShot;
            }
             else if (IsSpare(firstShot, secondShot))
            {
                score = 10 + firstShot;
            }
            else
            {
                score = firstShot + secondShot;
            }

            score += previousScore;
            listOfPlayers[nameOfPlayers] = score;

            return score;
        }

        public static void Play(Dictionary<string, int> listOfPlayers)
        {
            string nameOfPlayer;
            int firstShot;
            int secondShot;
            int scoreOfPlayer;
            foreach (string key in listOfPlayers.Keys)
            {
                nameOfPlayer = key;
                firstShot = Shot();
                secondShot = Shot();
                scoreOfPlayer = CalculateScore(firstShot, secondShot, listOfPlayers, nameOfPlayer);

                Console.WriteLine("Le joueur " + nameOfPlayer + " a le score : " + scoreOfPlayer);
                ShowScore(nameOfPlayer, firstShot, secondShot, scoreOfPlayer);
            }
        }

        }
    }


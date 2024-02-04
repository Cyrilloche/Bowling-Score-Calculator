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

            string[,] tableau = new string[5, 12];
            int counter = 1;
            Play(CreatePlayers(), counter, tableau);

            }

        public static string[,] ShowScore(string nameOfPlayer, int firstShot, int secondShot, int scoreOfPlayer, int counter, string[,] tableau)
        {
            Console.WriteLine("   ----------------------------------------------");
            Console.WriteLine("   |          Calculateur de Score de Bowling   |");
            Console.WriteLine("   ----------------------------------------------");

            Console.Write("   | Nom Joueur: " + nameOfPlayer);
            Console.WriteLine("   ----------------------------------------------");

            tableau[0, 0] = "   | Manche    ";
            tableau[1, 0] = "   |Lancer 1   ";
            tableau[2, 0] = "   |Lancer 2   ";
            tableau[3, 0] = "   |Total      ";

            tableau[1, counter] = $"|   {firstShot}   ";
            tableau[2, counter] = $"|   {secondShot}   ";
            tableau[3, counter] = $"|   {scoreOfPlayer}   ";

            for (int frame = 1; frame <= 10; frame++)
            {
                tableau[0, frame] = $"|   {frame}   ";
            }

            for (int row = 0; row < 4; row++)
            {
                for (int frame = 0; frame < 11; frame++)
                {
                    Console.Write(tableau[row, frame]);
                }
                Console.WriteLine();
                Console.WriteLine("   ----------------------------------------------");
            }

            Console.ReadLine();
            return tableau;
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

        public static int Shot( int previousShot = 0)
        {
            Random random = new Random();
            int shot = 0;
            if (previousShot != 0)
                shot = random.Next(0, 11 - previousShot);
            else 
                shot = random.Next(0, 11);
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

        public static void Play(Dictionary<string, int> listOfPlayers, int counter, string[,] tableau)
        {
            string nameOfPlayer;
            int firstShot;
            int secondShot;
            int scoreOfPlayer;
            while(counter <= 10)
            {
                foreach (string key in listOfPlayers.Keys)
                {  
                    nameOfPlayer = key;
                    firstShot = Shot();
                    secondShot = Shot(firstShot);
                    scoreOfPlayer = CalculateScore(firstShot, secondShot, listOfPlayers, nameOfPlayer);

                    Console.WriteLine("Le joueur " + nameOfPlayer + " a le score : " + scoreOfPlayer);
                    tableau = ShowScore(nameOfPlayer, firstShot, secondShot, scoreOfPlayer, counter, tableau);

                }
                counter++;
                Console.Clear();

            }
            
        }

        }
    }


string? option;
bool gameOver = false;
Random random = new Random();
List<Tuple<string, int>> previousGames = [];

ShowMenu();

while (gameOver == false)
{
    Console.Write("> ");
    option = Console.ReadLine();

    switch (option?.ToLower())
    {
        case "v":
            ViewPreviousGames();
            break;
        case "a":
            MathGame("Addition");
            break;
        case "s":
            MathGame("Subtraction");
            break;
        case "m":
            MathGame("Multiplication");
            break;
        case "d":
            MathGame("Division");
            break;
        case "q":
            gameOver = true;
            break;
        default:
            Console.WriteLine("error: Do not type anything other than the options.");
            break;
    }
}

void ShowMenu()
{
    Console.WriteLine("What game would you like to play today? Choose from the options below (uppercase or lowercase):");
    Console.WriteLine("V - View Previous Games");
    Console.WriteLine("A - Addition");
    Console.WriteLine("S - Subtraction");
    Console.WriteLine("M - Multiplication");
    Console.WriteLine("D - Division");
    Console.WriteLine("Q - Quit the program");
    Console.WriteLine("-------------------------------------------");
}

void MathGame(string option)
{
    int n1;
    int n2;

    int quotient;

    string? answer;
    string? nextQuestion;
    string? returnMenu;

    int score = 0;
    int correctAnswers = 0;

    string sign = option switch
    {
        "Addition" => "+",
        "Subtraction" => "-",
        "Multiplication" => "*",
        _ => "/"
    };

    while (true)
    {
        n1 = random.Next(100);
        n2 = random.Next(100);

        if (sign == "/")
        {
            while (true)
            {
                n1 = random.Next(100);
                n2 = random.Next(1, 100);
                quotient = n1 / n2;
                if (n1 == n2 * quotient)
                    break;
            }
        }

        Console.WriteLine($"{option} game");
        Console.WriteLine($"{n1} {sign} {n2}");
        Console.Write("Answer: ");
        answer = Console.ReadLine(); // Let's consider the user typed an integer value
        int result = sign switch
        {
            "+" => n1 + n2,
            "-" => n1 - n2,
            "*" => n1 * n2,
            "/" => n1 / n2,
            _ => 0
        };

        if (Convert.ToInt32(answer) == result)
        {
            score += 5;
            correctAnswers = score / 5;
            Console.WriteLine("Your answer was correct! Type any key for the next question");
            nextQuestion = Console.ReadLine();
            if (nextQuestion?.Length > 0)
                continue;
        }
        else
        {
            previousGames.Add(Tuple.Create(option, score));

            Console.WriteLine($"Game Over. Your final score is {score} ({correctAnswers} correct answers). Press any key to go back to the menu");
            returnMenu = Console.ReadLine();
            if (returnMenu?.Length > 0 || string.IsNullOrEmpty(returnMenu))
            {
                ShowMenu();
                break;
            }
        }
    }
}

void ViewPreviousGames()
{
    string? returnMenu;

    Console.WriteLine("Previous Games: \n");

    foreach (Tuple<string, int> game in previousGames)
    {
        Console.WriteLine($"{game.Item1} : {game.Item2} points");
    }
    Console.WriteLine("\nPress any key to go back to the menu");
    returnMenu = Console.ReadLine();
    if (returnMenu?.Length > 0 || string.IsNullOrEmpty(returnMenu))
        ShowMenu();
}
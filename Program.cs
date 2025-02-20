// Brett Barnes, February 19, 2025, Programming Fundamentals Lab 1405
Console.WriteLine("Welcome to Madlibs!");
Console.WriteLine("This game will ask you for words to complete a story, any will do. Have fun, and enjoy!");
Console.WriteLine("Hint: Words that fit the request will make the story better!");

string originalStory = "One (adjective) day aboard the spaceship, a (adjective) (noun) does a routine (noun) check near the airlock. Everything seems (adjective) until suddenly, a loud (noun) echoes through the ship. Without warning, the airlock pops open, and poor (noun) floats through the void of space! '(Exclamation)!' they shout, waving an arm as they drift further from the ship. Back on the bridge, Captain (noun) slams a (noun) in frustration. 'We must grab them before they run out of (liquid)!' Meanwhile, (noun) spots a nearby (noun) and uses a (noun) to push toward it. After a tense moment, they land on the airlock just as the crew pulls it shut. Breathing hard, (noun) mutters, '(exclamation),' vowing never to go near the airlock again.";
string[] storyWords = originalStory.Split(' ');
string[] placeholders = new string[storyWords.Length];
string[] userInputs = new string[storyWords.Length];


for (int i = 0; i < storyWords.Length; i++)
{
    string word = storyWords[i];

    if (ContainsChars(word, '(', ')'))
    {
        string placeholder = ExtractPlaceHolder(word);
        string punctuation = GetPunctuation(word);

        string userInput = "";

        if (placeholder == "adjective")
        {
            Console.WriteLine("Please give me an adjective: ");
            userInput = Console.ReadLine();
        }
        else if (placeholder == "noun")
        {
            Console.WriteLine("Please give me a noun: ");
            userInput = Console.ReadLine();
        }
        else if (placeholder == "exclamation")
        {
            Console.WriteLine("Please give me an exclamation: ");
            userInput = Console.ReadLine();
        }
        else if (placeholder == "liquid")
        {
            Console.WriteLine("Please give me a liquid: ");
            userInput = Console.ReadLine();
        }
       
        userInput = RemoveSpacesFromEdges(userInput);

        string article = IsVowel(userInput) ? "an" : "a";
        
        storyWords[i] = article + " " + userInput + punctuation;
        placeholders[i] = placeholder;
        userInputs[i] = userInput;
    }
}

string RemoveSpacesFromEdges(string input)
{
    int start = 0;
    int end = input.Length - 1;

    while (start <= end && input[start] == ' ')
    {
        start++;
    }

    while (end >= start && input[end] == ' ')
    {
        end--;
    }

    string result = "";
    for (int i = start; i <= end; i++)
    {
        result += input[i];
    }

    return result;
}

string finalStory = "";
foreach (string word in storyWords)
{
    finalStory += word + " ";
}

 Console.WriteLine();
 Console.WriteLine("Your Space Adventure");
 Console.WriteLine();
 Console.WriteLine(finalStory);

 bool ContainsChars(string input, char open, char close)
 {
    bool foundOpen = false;
    foreach (char c in input)
    {
        if (c == open)
        {
            foundOpen = true;
        }
        else if (c == close && foundOpen)
        {
            return true;
        }
    }
    return false;
 }

 string ExtractPlaceHolder(string word)
 {
    bool recording = false;
    string placeholder = "";
    foreach (char c in word)
    {
        if (c == '(')
        {
            recording = true;
        }
        else if (c == ')')
        {
            recording = false;
        }
        else if (recording)
        {
            placeholder += c;
        }
    }
    return placeholder;
 }

 string GetPunctuation(string word)
 {
    bool passedPlaceholder = false;
    string punctuation = "";
    foreach(char c in word)
    {
        if (c == ')')
        {
            passedPlaceholder = true;
        }
        else if (passedPlaceholder)
        {
            punctuation += c;
        }
    }
    return punctuation;
 }

 bool IsVowel(string word)
 {
    if (word.Length == 0)
    {
        return false;
    }

    char firstChar = char.ToLower(word[0]);
    return firstChar == 'a' || firstChar == 'e' || firstChar == 'i' || firstChar == 'o' || firstChar == 'u';
 }
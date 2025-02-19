// Brett Barnes, February 19, 2025, Programming Fundamentals Lab 1405
Console.WriteLine("Welcome to Madlibs!");
Console.WriteLine("This game will ask you for words to complete a story, any will do. Have fun, and enjoy!");
Console.WriteLine("Hint: Words that fit the request will make the story better!");

string originalStory = "One (adjective) day aboard the spaceship (name of spaceship), (name of astronaut) was doing a routine (noun) check near the airlock. Everything seemed (adjective) until suddenly, a loud (sound effect) echoed through the ship. Without warning, the airlock (verb ending in -ed) open, and poor (same name of astronaut) was (verb ending in -ing) through the void of space! \"(exclamation)!\" they shouted, flailing their (body part plural) as they drifted further from the ship. Back on the bridge, Captain (name) slammed a (object) in frustration. \"We need to (verb) them back before they run out of (liquid)!\" Meanwhile, (same name of astronaut) spotted a nearby (space object) and used their (tool) to propel themselves towards it. After a tense moment, they finally (verb ending in -ed) onto the airlock just as the crew (verb ending in -ed) it shut. Breathing heavily, (same name of astronaut) muttered, \"(silly phrase),\" vowing never to (verb) near the airlock again.";

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

        string basePlaceholder = RemoveSamePrefix(placeholder);

        string userInput = "";

        for (int j = 0; j < i; j++)
        {
            if (placeholders[j] == basePlaceholder)
            {
                userInput = userInputs[j];
                break;
            }
        }

        if (userInput == "")
        {
            string article = "a";
            char firstChar = char.ToLower(placeholder[0]);
            if (firstChar == 'a' || firstChar == 'e' || firstChar == 'i' || firstChar == 'o' || firstChar == 'u')
            {
                article = "an";
            }
            Console.Write("Please give me " + article + " " + placeholder + ": ");
            userInput = Console.ReadLine();
        }

        storyWords[i] = userInput + punctuation;
        placeholders[i] = placeholder;
        userInputs[i] = userInput;
    }
}

string finalStory = "";
bool firstWord = true;
foreach (string word in storyWords)
{
    if (firstWord)
    {
        finalStory += word;
        firstWord = false;
    }
    else
    {
        finalStory += " " + word;
    }
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

 string RemoveSamePrefix(string placeholder)
 {
    string result = "";
    string prefix = "same";
    int prefixLength = prefix.Length;
    int index = 0;

    while (index < prefixLength && index < placeholder.Length && placeholder[index] == prefix[index])
    {
        index++;
    }

    if (index == prefixLength)
    {
        for (int i = prefixLength; i < placeholder.Length; i++)
        {
            result += placeholders[i];
        }
    }
    else
    {
        result = placeholder;
    }

    return result;
 }
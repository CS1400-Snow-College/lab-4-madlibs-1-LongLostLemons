// Brett Barnes, February 19, 2025, Programming Fundamentals Lab 1405

Console.WriteLine("Welcome to Madlibs!");
Console.WriteLine("This game will ask you for words to complete a story, any will do. Have fun, and enjoy!");
Console.WriteLine("Hint: Words that fit the request will make the story better!");

string originalStory = "One (adjective) day aboard the spaceship (name of spaceship), (name of astronaut) was doing a routine (noun) check near the airlock. Everything seemed (adjective) until suddenly, a loud (sound effect) echoed through the ship. Without warning, the airlock (verb ending in -ed) open, and poor (same name of astronaut) was (verb ending in -ing) through the void of space! \"(exclamation)!\" they shouted, flailing their (body part plural) as they drifted further from the ship. Back on the bridge, Captain (name) slammed a (object) in frustration. \"We need to (verb) them back before they run out of (liquid)!\" Meanwhile, (same name of astronaut) spotted a nearby (space object) and used their (tool) to propel themselves towards it. After a tense moment, they finally (verb ending in -ed) onto the airlock just as the crew (verb ending in -ed) it shut. Breathing heavily, (same name of astronaut) muttered, \"(silly phrase),\" vowing never to (verb) near the airlock again.";

string[] storyWords = originalStory.Split(' ');

for (int i = 0; i < storyWords.Length; i++)
{
    string word = storyWords[i];

    if (word.Contains("(") && word.Contains(")"))
    {
        int start = word.IndexOf('(');
        int end = word.IndexOf(')');
        string placeholder = word.Substring(start + 1, end - start - 1);
        string punctuation = word.Length > end + 1 ? word.Substring(end + 1) : "";

        string article = StartsWithVowel(placeholder) ? "an" : "a";
        Console.Write($"Plese give me {article} {placeholder}: ");
        string userInput = Console.ReadLine();

        storyWords[i] = userInput + punctuation;
    }
}

string finalStory = "";
foreach (string word in storyWords)
{
    finalStory += word + " ";
}

Console.WriteLine("Your Space Adventure");
Console.WriteLine(finalStory);

static bool StartsWithVowel(string word)
{
    char firstChar = word[0];
    return firstChar == 'a' || firstChar == 'e' || firstChar == 'i' || firstChar == 'o' || firstChar == 'u' || firstChar == 'A' || firstChar == 'E' || firstChar == 'I' || firstChar == 'O' || firstChar == 'U';
}
public static class Prompt
{
    private static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was something strange that happened today?",
        "What is a new goal you have?",
        "What is something you achieved today?",
        "What did you learn today?"
    };

    public static string getRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(prompts.Count);
        return prompts[randomIndex];
    }

    public static void addPrompt(string prompt)
    {
        prompts.Add(prompt);
    }
}
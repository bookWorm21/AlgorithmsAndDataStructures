namespace AlgorithmsDataStructures
{
    public class BracketSequenceChecker
    {
        public static bool Check(string sequence)
        {
            var openBrackets = new Stack<char>();
            foreach (var symbol in sequence)
            {
                if (symbol == '(')
                {
                    openBrackets.Push(symbol);
                    continue;
                }

                if (symbol != ')')
                {
                    continue;
                }

                if (openBrackets.Size() > 0)
                {
                    openBrackets.Pop();
                }
                else
                {
                    return false;
                }
            }
            
            return openBrackets.Size() == 0;
        }
    }
}
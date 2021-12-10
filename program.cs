class Program
    {
        static void Words(string line, char[] delimiters, string singleWord,
                            StringBuilder mystringBuilder)
        {
            string lineToSplit = line;
            string[] words = lineToSplit.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string extra = " " + line + " ";
            int init = 1;
            int counter = 0;
            int ind = 0;
            foreach (string word in words)
            {
                if (word.ToLower() == singleWord.ToLower())
                {
                    if (counter == 0)
                    {
                        ind = extra.IndexOf(word);
                        counter++;
                    }
                    else ind = extra.IndexOf(word, ind + 1);

                    if (ind >= init + 1) mystringBuilder.Append(extra.Substring(init, ind - init - 1));
                    else mystringBuilder.Append(extra.Substring(init, 0));
                    init = ind + singleWord.Length;
                }
            }
            mystringBuilder.Append(line.Substring(init - 1));
        }

        static void Process(string fd, string fr, char[] delimeters, string singleWord)
        {
            using (StreamReader reader = new StreamReader(fd))
            {
                using (StreamWriter fra = new StreamWriter(fr, false))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        StringBuilder appendedStringBuilder = new StringBuilder();
                        Words(line, delimeters, singleWord, appendedStringBuilder);
                        fra.WriteLine(appendedStringBuilder);
                    }
                }
            }
        }
        const string CFd = "Data.txt";
        const string CFr = "Results.txt";
        static void Main(string[] args)
        {
            char[] delimiters = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            Console.WriteLine("Enter the searching word");
            string singleWord = Console.ReadLine();
            Process(CFd, CFr, delimiters, singleWord);
        }
    }

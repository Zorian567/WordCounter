using System.Diagnostics.Metrics;
using System.Text;

namespace WordCounter {
        class Program {
            static void Main(){
            
            string inputString = File.ReadAllText("input.txt");

            System.Console.Write("Insert a word to count: ");
            string wordToSeek = Console.ReadLine();

            int wordCount = WordCounter(inputString, wordToSeek);

            string[] wordsArrayGlobal = wordSplitter(inputString);

            int stringLength = wordsArrayGlobal.Length;
            
            System.Console.WriteLine(wordCount);
            System.Console.WriteLine(stringLength);

            double frequency = (double)wordCount / stringLength;


            System.Console.WriteLine(frequency);
            var csv = new StringBuilder();

            var newLine = string.Format("{0},{1},{2}", wordToSeek, wordCount, frequency);
            csv.AppendLine(newLine);  

            File.WriteAllText("output.csv", csv.ToString());
    
            }

            static int WordCounter(string input, string wordToCount){
                
                string[] words = wordSplitter(input);

                int counter = 0;
                
                foreach (string i in words) {
                    if (i == wordToCount) {

                        counter += 1;

                    }
                }
                
                System.Console.WriteLine("Words counted successfully.");
                return counter;
            }
            static string[] wordSplitter(string input){

                string[] words = input.Split(' ', '.', ',', '!', '?');
                return words;

            }
        }
}
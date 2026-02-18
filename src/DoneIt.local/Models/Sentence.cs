namespace DoneIt.Models;

class Sentence
{
   string[] words = "The quick brown fox".Split();   

   //implementing indexer
   public string this[int index]
   {
      get { return words[index]; }
      set { words[index] = value; }
   }
}

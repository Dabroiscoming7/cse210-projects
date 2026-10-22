using System.Reflection.Metadata.Ecma335;

class Scripture
{
    private List<Word> _words;

    // TODO - Add scripture Refrence

    public Scripture (string bookName, int chapter, int verse, string text)
    {
        _words = ConvertToWordList(text);
        
        _words[7].Hide();
        //todo
    }

    public Scripture (string bookName, int chapter, int startverse, int endVerse, string text)
    {
        //todo
    }

    public void ShowScripture()
    {
        foreach(Word word in _words)
        {
            word.Display();
        }
    }

    //TODO - Add constrctor for ScriptureRefrence

    /***************************************
    * ConvertToWordList() - this method will recieve a string parameter,
    * which is a paragraph of text. It will split that text into words and
    * add those words to a List<word> and return the list
    ****************************************/

    private List<Word> ConvertToWordList(string text)
    {
        List<Word> tempWordList = new List<Word>();
        string[] tempWords = text.Split(' ');
        foreach(string w in tempWords)
        {
            Word tempWord = new Word(w);
            tempWordList.Add(tempWord);
        }

        return tempWordList;
    }

    
}
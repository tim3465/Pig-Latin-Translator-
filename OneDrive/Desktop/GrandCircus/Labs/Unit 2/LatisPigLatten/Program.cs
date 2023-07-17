

using System.Text.RegularExpressions;

Console.WriteLine("Welcome to the Pig Latin Translator!\n");
string run = "y";
while (run == "y")
{
    Console.Write("Enter a line to be translated: ");
    string entrey = Console.ReadLine().Trim();
    //The line directly under this takes out extra white spaces 
    entrey = Regex.Replace(entrey, @"\s+", " ");

    


    string pigstring = "";
    //Iterates through each word And determines whether or not it should be translated then sends it to the method for translation 
foreach (string wordSplit in entrey.Split(' '))
    {
        string word=wordSplit;
        //Check for punctuation 
        string punctuationChar="";
        bool punctuation = CheckForPunctuation(ref word,ref punctuationChar);

        //Getting caps key looks at the letters of the word and determines
        //whether the word is all Capital, the first letter is capital, or all lower case 
        string isItCapsKey = GitingCapKey(word);

        //If the word contains nothing but alphabetical letters and or ' Then it will convert it to pig Latin.
        //And add the word to the pigString. 
        if (ChekingForAllAlphabet(word.ToLower()))
        {
            if (punctuation)
            {
                pigstring += ConvertingToPigLaten(word, isItCapsKey) +punctuationChar+ " ";
            }
            else
            {
                pigstring += ConvertingToPigLaten(word, isItCapsKey) + " ";
            }
        }
        else
        {
            if (punctuation)
            {
                pigstring += word + punctuationChar + " ";
            }
            else
            {
                pigstring += word + " ";
            }
        }
    }
    pigstring=pigstring.Trim();
    Console.WriteLine("\n"+pigstring+"\n");

    //Conditional loop to determine if the user wishes to continue or not.
    while (true)
    {
        Console.Write("Translate another line ? (y / n): ");
        run = Console.ReadLine().ToLower().Trim();
        if (run != "y" && run != "n")
        {
            Console.WriteLine("Invalid entry! \n");
        }
        else
        {
            break;
        }
    }
}

    //Metheds 

//This method converts the word to pig Latin it also uses ConvertToCapitalsOrNot method
//to appropriate the capital letters.
    static string ConvertingToPigLaten(string word ,string capsKey)
    {

        word = word.ToLower();
        if (word[0] == 'a' || word[0] == 'e' || word[0] == 'i' || word[0] == 'o' || word[0] == 'u')
        {
            word= word + "way";
            word= ConvertToCapsOrNot(word, capsKey);
            return word;
        }

        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
            {
            word = word.Substring(i) + word.Substring(0, i) + "ay";
            word = ConvertToCapsOrNot(word, capsKey);
            return word ;
            }
        }
        return word;
    }

//This method checks every Character of a word, to make sure it's a letter of the alphabet And Oregon apostrophe.
static bool ChekingForAllAlphabet(string word)
{
    char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '\''};
   
    foreach (char ch in word)
    {
        bool alphChar = false;
        foreach(char ch2 in alphabet)
        {
            if (ch2== ch)
            { 
                alphChar=true; 
                break;
            }
        }
        if (alphChar)
        {
            continue;
        }
        else
        {
            return false;
        }
    }
    return true;
}


//This method determines whether the word is capital case title case or lower case then it creates a key in a string
//zero is capital case One is title case two is lower case.
 static string GitingCapKey(string words)
{
    //Iterates through each character puts a C if it's Capitalcase  and in L if it's Lowercase  
        string word = "";
       foreach (char ch in words)
        {
            if (char.IsUpper(ch))
            {
                word += "c";
            }
            else
            {
                word += "l";
            }
        }

       //looks at the first two elements of the string determines whether it should be
       //lower case title case or capital case  
    if (word.ElementAt(0) == 'c')
    {
        if (word.Length > 2)
        {
            if (word.ElementAt(1) == 'c')
            {
                words = "0";
            }
            else
            {
                words = "1";
            }
        }
        else
        {
            words = "0";
        }
    }
    else
    {
        words = "2";
    }
    //0 is all caps 
    //1 first is caps rest is lower
    //2 all lower
    return words;
}

//This method converts the appropriate letters from lower case to upper case using the key
//Given by the GitingCapKey Method 
static string ConvertToCapsOrNot(string word,string capKey)
{
    switch (capKey)
    {
        case "0":
                word=word.ToUpper(); 
            return word;
            case "1":
            word= char.ToUpper(word[0]).ToString()+word.Substring(1);
            return word;
            case "2":
            return word.ToLower();
    }
    return word;
}

//This method removes the punctuation at the end of a word and stores it in the punctuation variable then sets a bull value
//so it can be replaced in the main program.
static bool CheckForPunctuation(ref string word , ref string punctuation)
{
    punctuation = "";
    if (word[word.Length-1]== '.'|| word[word.Length - 1] == ',' || word[word.Length - 1] == '!' || word[word.Length - 1] == ':'|| word[word.Length - 1] == '?')
    {
        punctuation = word[word.Length-1].ToString();
        //Convert the string to a character array then resizing it
        //to truncate the punctuation off  String then converts the array back to string 
        char[] wordArray =word.ToCharArray();
        Array.Resize(ref wordArray, wordArray.Length-1);
        word = string.Join("", wordArray);
        return true;
    }
    else
    {
        return false;
    }
}
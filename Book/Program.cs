using System;

class Book
{
    private string title;
    private string content;
    private string eTitle;
    private string eContent;
    private double value = 0;
    private int pages = 0;
    private double titleValue = 0;
    private double contentValue = 0;
    private int i = 0;

    public Book()
    {
        title = "Very nice book.";
        content = "This is a testing book.";
        value = 15.5;
        pages = 8;
    }

    public Book(string bookName, string bookContent)
    {
        //Find Title and Content Value
        for (i = 0; i < title.Length; i++)
        {
            if (bookName[i] != ' ' && bookName[i] != '\t' && bookName[i] != '\n')
            {
                titleValue += .5;
            }
        }

        for (i = 0; i < content.Length; i++)
        {
            if (bookContent[i] != ' ' && bookContent[i] != '\t' && bookContent[i] != '\n')
            {
                contentValue += .5;
            }
        }

        //Get Book and Pages Value
        value = titleValue + contentValue;
        pages = Convert.ToInt32(titleValue + contentValue / 5);
    }

    public void encrypt(int key)
    {
        //Initialize char and string values for later use
        char a;
        char b;

        string newTitle = "";
        string newContent = "";

        //Set strings as capital letters (for encryption)
        eTitle = title.ToUpper();
        eContent = content.ToUpper();

        //Cycle through title
        for (i = 0; i < eTitle.Length; i++)
        {
            //Initialize chars and ints for math
            a = Convert.ToChar(eTitle.Substring(i, 1));
            int x = Convert.ToInt32(a);
            x += key;

            //Conditions to keep values within ASCII values
            if (x > 90)
            {
                int temp = x % 90;
                x = 65 + temp;
            }

            //Convert int back to char
            b = Convert.ToChar(x);

            //Add back to updated title string
            newTitle += Convert.ToString(Convert.ToChar(b));
        }
        title = newTitle;

        //Encrypt 
        for (i = 0; i < eContent.Length; i++)
        {
            //Repeat title process
            a = Convert.ToChar(eContent.Substring(i, 1));
            int x = Convert.ToInt32(a);
            x += key;

            //Conditions to keep values within ASCII values
            if (x > 90)
            {
                int temp = x % 90;
                x = 65 + temp;
            }

            //Convert int back to char
            b = Convert.ToChar(x);
            newContent += Convert.ToString(Convert.ToChar(b));
        }
        content = newContent;
    }

    public string getTitle()
    {
        return title;
    }

    public string getContents()
    {
        return content;
    }

    public double getValue()
    {
        return value;
    }

    public int getPages()
    {
        return pages;
    }

    public void print()
    {
        Console.WriteLine("Title: {0}", title);
        Console.WriteLine("Body: {0}", content);
        Console.WriteLine("Value: ${0:F1}", value); 
        Console.WriteLine("Pages: {0}", pages);
    }
}
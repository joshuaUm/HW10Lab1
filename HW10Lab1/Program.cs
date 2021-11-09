/// Homework No. 10 Lab No. 1
/// File Name : Program.cs
/// @author : Joshua Um
/// Date : November 8 2021
/// 
/// Problem Statement : Define a class Document with child classes Email and File, test objects by passing them through ContainsKeyword().
/// 
/// Plan:
/// 1. Create 2 Email objects.
/// 2. Create 2 File objects.
/// 3. Set keyword value to any string.
/// 4. Store objects in Document array.
/// 5. Loop through each document child object.
/// 6. pass each object through ContainsKeyword() to check text field for keyword, return true if keyword found, return false if otherwise.

using System;

namespace HW10Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Email email1 = new Email("Important", "Joe", "Also Joe", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean tristique dolor eget lectus pulvinar, rhoncus maximus justo laoreet. Donec et est id lectus interdum porttitor non et risus. Sed eu pellentesque purus. In a lacus et diam accumsan tempor. Fusce vel eleifend justo. In fermentum arcu quam, et porta lectus fringilla eu. Pellentesque diam ipsum, tempus eu sem eleifend, dapibus sodales eros. Donec vulputate semper ligula. Fusce eget ultrices mi. Etiam vulputate lectus in venenatis consectetur.");
            Email email2 = new Email("Not Important", "Not Joe", "Steve", "Curabitur suscipit eros quis sapien viverra interdum. Morbi ultrices mi nec lacus vulputate, vitae scelerisque enim commodo. Sed aliquam orci non magna auctor dictum. Morbi convallis vulputate ex ac vulputate. Praesent non lorem eu enim ullamcorper finibus nec quis quam. Pellentesque pharetra rhoncus ante, vitae dignissim erat laoreet elementum. Vestibulum vitae feugiat mi. Praesent sollicitudin blandit nunc quis aliquam. Aenean posuere luctus mollis. Aenean ut lacus mattis, blandit sapien ut, mattis risus. Vivamus feugiat imperdiet ullamcorper.");

            File file1 = new File("C:/Users/Desktop", "Aenean odio nibh, tempor non turpis quis, finibus pellentesque lacus. Integer ut accumsan enim. Mauris sem leo, maximus sed tellus sed, vehicula pretium nibh. Phasellus et purus ac est euismod ornare nec ut nisl. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur euismod nisl augue, eget fermentum dolor efficitur id. Etiam quis lorem eget sem luctus placerat ac id lorem. In hac habitasse platea dictumst. Nulla fringilla augue id sem sodales, at condimentum mi fringilla.");
            File file2 = new File("C:/System32", "Etiam eget hendrerit arcu, semper euismod dui. Ut iaculis bibendum ante at ultrices. Donec dapibus mauris sit amet odio ornare, nec sollicitudin felis consequat. Nunc malesuada urna libero, sit amet condimentum est dapibus at. Suspendisse id sem non ante egestas luctus vitae eget odio. Vivamus et sodales elit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Nunc pulvinar semper dui, et ultrices felis. Sed metus nibh, porttitor in eros et, elementum cursus dolor.");

            Document[] docArray = { email1, email2, file1, file2 };
            const string KEYWORD = "sit";

            for(int i = 0 ,count = docArray.Length; i < count; i++)
            {
                Console.WriteLine(docArray[i]);
                Console.WriteLine("Document #" + i + " Contains Keyword \"" + KEYWORD + "\" :" + ContainsKeyword(docArray[i], KEYWORD));
            }
                
        }

        public static bool ContainsKeyword(Document docObject, string keyword)
        {

            if (docObject.ToString().IndexOf(keyword, 0) >= 0)
            {

                return true;

            }

            return false;

        }




    }





    public class Document
    {
        public string Text { get; set; }
        


        public Document()
        {
            Text = "";
        }

        public Document(string Text)
        {
            this.Text = Text;
        }

        public override string ToString()
        {
            return "\n" + Text;
        }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Document))
            {
                return false;
            }

            Document other = (Document)obj;

            return Text.Equals(other.Text);
        }
    }

    public class Email : Document
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Title { get; set; }


        public Email() : base()
        {
            this.Title = "";
            this.Sender = "";
            this.Recipient = "";   
        }

        public Email(string Title , string Sender, string Recipient , string Text) : base(Text)
        {
            this.Title = Title;
            this.Sender = Sender;
            this.Recipient = Recipient;
        }



        public override string ToString()
        {
            return "\n\tTitle : "+ Title + "\n\tSender : " + Sender + "\n\tRecipient:" +  Recipient  + "\n" + base.ToString();
        }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Email))
            {
                return false;
            }

            Email other = (Email)obj;

            return base.Equals(obj) && Sender.Equals(other.Sender) && Recipient.Equals(other.Recipient) && Title.Equals(other.Title);
        }
    }

    public class File : Document 
    { 
        public string PathName { get; set; }

        public File() : base()
        {
            this.PathName = "";
        }

        public File(string PathName, string Text) : base(Text)
        {
            this.PathName = PathName;
        }


        public override string ToString()
        {
            return "\nPathName : " + PathName + "\n" + base.ToString();
        }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is File))
            {
                return false;
            }

            File other = (File)obj;

            return base.Equals(obj) && PathName.Equals(other.PathName);
        }

    }

}

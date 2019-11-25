using System;
using System.Text;

namespace CollectionHierarchy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine().Split();
            var itemsToDelete = int.Parse(Console.ReadLine());
           
            var sb = new StringBuilder();
            var addCollection = new AddCollection();
           
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append($"{addCollection.Add(text[i])} ");
            }
            sb.AppendLine();   

            var addRemoveCollection = new AddRemoveCollection();
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append($"{addRemoveCollection.Add(text[i])} ");
            }
            sb.AppendLine();

            var myCollection = new MyList();
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append($"{myCollection.Add(text[i])} ");
            }
            sb.AppendLine();
            
            for (int i = 0; i < itemsToDelete; i++)
            {
                sb.Append($"{addRemoveCollection.Remove()} ");
            }
            sb.AppendLine();
           
            for (int i = 0; i < itemsToDelete; i++)
            {
                sb.Append($"{myCollection.Remove()} ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}

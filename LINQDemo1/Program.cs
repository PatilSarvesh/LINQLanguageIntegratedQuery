namespace LINQDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3,4,5,6,7,8,9 };
            //select all even number into separate collection and display

            //table: numbers
            //colume: number
            //
            //SQL Query: Select number from numbers where number mod 2 ==0;
            //LINQ Query


            var a = 10;
            var name = "jkkcn";
            var xyz = 123132.12441;

            var result = from en in numbers
                         where en % 2 == 0
                         select en;



            List<int> evens = new List<int>();

            foreach (var i in numbers)
            {
                if(i%2 == 0)
                {
                    evens.Add(i);
                }
            }



            foreach (var i in evens)
            {
                Console.WriteLine(i);
            }

        }
    }
}
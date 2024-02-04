using System.Text.RegularExpressions;

namespace RegExp_home
{
    internal class Program
    {
        static List<int> Filter4digitNums(params int[] nums)
        {
            List<int> list = new List<int>();
            string pattern = @"^\d{4}$";
            var reg = new Regex(pattern);
            foreach (var item in nums)
            {                
                if (reg.IsMatch(item.ToString()))
                {
                    list.Add(item);   
                }
            }
            return list;
        }
        static List<string> FilterStringsByPattern(string pattern, params string[] nums)
        {
            List<string> list = new List<string>();
            
            var reg = new Regex(pattern);
            foreach (var item in nums)
            {
                if (reg.IsMatch(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        static List<string> NumberFormat(params string[] nums)
        {
            List<string> list = new List<string>();
            foreach (var item in nums)
            {
                var line = Regex.Replace(item, @"\d{9}", i => string.Format("{0:+38(0##)##-##-###}", Convert.ToInt64(i.Value)));
                list.Add(line);    
            }

            return list;
        }

        static void Main(string[] args)
        {
            var list = Filter4digitNums(12321, 46478, 1, 23, 236, 7989, 4564, 7488, 8956);
            foreach (var item in list)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            string pattern = @"^[A-Za-z]{3}[0-9]{3}[A-Za-z]{3}[0-9]{3}$";
            var words = FilterStringsByPattern(pattern, "asd123zxc456", "bnm674ljk890", "bnm1674ljk890");
            foreach (var item in words)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();

            pattern = @"^[A-Z]{3}$";
            var line = FilterStringsByPattern(pattern, "jks", "!@#", "123", "AAAA", "WWW", "BMP", "JPeG");
            foreach (var item in line)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();

            pattern = @"^19\d\d$|^20\d\d$";
            line = FilterStringsByPattern(pattern, "1918", "1785", "2020", "2100", "2055", "2063", "1945");
            foreach (var item in line)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();


            var phones = NumberFormat("456461323","748745649", "787908561", "126900563","0126900563");

            foreach (var item in phones)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();



            string pat = @"^\+38\(0\d{2}\)\d{2}-\d{2}-\d23$";
            var nums = FilterStringsByPattern(pat, phones.ToArray());
            foreach (var item in nums)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();

            string pat2 = @"^\+38\(0\d{2}\)\d{2}-00-\d{3}$";
            var nums2 = FilterStringsByPattern(pat2, phones.ToArray());
            foreach (var item in nums2)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();


        }
    }
}
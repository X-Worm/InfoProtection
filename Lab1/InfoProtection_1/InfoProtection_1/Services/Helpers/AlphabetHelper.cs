using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProtection_1.Services.Helpers
{
    public class AlphabetHelper
    {
        public AlphabetHelper()
        {

        }

        public List<KeyValuePair<int, char>> GetUkraineAlphabet()
        {
            var result = new List<KeyValuePair<int, char>>();
            result.Add(new KeyValuePair<int, char>(1, 'А'));
            result.Add(new KeyValuePair<int, char>(2, 'Б'));
            result.Add(new KeyValuePair<int, char>(3, 'В'));
            result.Add(new KeyValuePair<int, char>(4, 'Г'));
            result.Add(new KeyValuePair<int, char>(5, 'Ґ'));
            result.Add(new KeyValuePair<int, char>(6, 'Д'));
            result.Add(new KeyValuePair<int, char>(7, 'Е'));
            result.Add(new KeyValuePair<int, char>(8, 'Є'));
            result.Add(new KeyValuePair<int, char>(9, 'Ж'));
            result.Add(new KeyValuePair<int, char>(10, 'З'));
            result.Add(new KeyValuePair<int, char>(11, 'И'));
            result.Add(new KeyValuePair<int, char>(12, 'І'));
            result.Add(new KeyValuePair<int, char>(13, 'Ї'));
            result.Add(new KeyValuePair<int, char>(14, 'Й'));
            result.Add(new KeyValuePair<int, char>(15, 'К'));
            result.Add(new KeyValuePair<int, char>(16, 'Л'));
            result.Add(new KeyValuePair<int, char>(17, 'М'));
            result.Add(new KeyValuePair<int, char>(18, 'Н'));
            result.Add(new KeyValuePair<int, char>(19, 'О'));
            result.Add(new KeyValuePair<int, char>(20, 'П'));
            result.Add(new KeyValuePair<int, char>(21, 'Р'));
            result.Add(new KeyValuePair<int, char>(22, 'С'));
            result.Add(new KeyValuePair<int, char>(23, 'Т'));
            result.Add(new KeyValuePair<int, char>(24, 'У'));
            result.Add(new KeyValuePair<int, char>(25, 'Ф'));
            result.Add(new KeyValuePair<int, char>(26, 'Х'));
            result.Add(new KeyValuePair<int, char>(27, 'Ц'));
            result.Add(new KeyValuePair<int, char>(28, 'Ч'));
            result.Add(new KeyValuePair<int, char>(29, 'Ш'));
            result.Add(new KeyValuePair<int, char>(30, 'Щ'));
            result.Add(new KeyValuePair<int, char>(31, 'Ь'));
            result.Add(new KeyValuePair<int, char>(32, 'Ю'));
            result.Add(new KeyValuePair<int, char>(33, 'Я'));

            return result;
        }
    }
}

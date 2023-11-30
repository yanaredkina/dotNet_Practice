using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task6
{
    public class EngRusDict
    {
        private Dictionary<string, HashSet<string>> _data = new Dictionary<string, HashSet<string>>();

        enum Language
        {
            ENGLISH,
            RUSSIAN,
            UNKNOWN
        };


        #region Add Method with one translation
        public void Add(string? word, string? translation)
        {
            // checking null or empty input
            if (string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(translation))
            {
                throw new ArgumentException("ERROR in input: word or translation cannot be empty");
            }

            //checking languages
            word = word.Trim();
            Language wlang = DetectLanguage(word);
            if (wlang == Language.UNKNOWN)
            {
                throw new ArgumentException($"ERROR in '{word}': input words must be English or Russian only");
            }

            translation = translation.Trim();
            Language tlang = DetectLanguage(translation);

            if (tlang == Language.UNKNOWN)
            {
                throw new ArgumentException($"ERROR in '{translation}': translation must be English or Russian only");
            }

            // checking language compliance
            if (wlang == tlang)
            {
                throw new ArgumentException($"ERROR in pair ({word}-{translation}): word and translation must be in dfferent languages");
            }

            // adding to dict with checking duplicates (there will be no exceptions - all cases are monitored)
            word = word.ToLower();
            translation = translation.ToLower();

            if (_data.ContainsKey(word))
            {
                _data[word].Add(translation);
            } else
            {
                _data.Add(word, new HashSet<string>() { translation });
            }

            if (_data.ContainsKey(translation))
            {
                _data[translation].Add(word);
            } else
            {
                _data.Add(translation, new HashSet<string>() { word });
            }

            Console.WriteLine($"Pair ({word}-{translation}) was successfully added in dictionary");
        }
        #endregion


        #region Add Method with multiple translations
        public void Add(string? word, List<string> translations) 
        {
            string errors = "";
            foreach (var translation in translations)
            {
                try
                {
                    this.Add(word, translation);
                }
                catch (ArgumentException e)
                {
                    errors += e.Message + '\n';
                }
            }

            if (!string.IsNullOrEmpty(errors))
            {
                throw new ArgumentException(errors);
            }
        }
        #endregion


        #region GetTranslations Method
        public List<string>? GetTranslations(string? word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("ERROR in input: word cannot be empty");
            }

            word = word.Trim().ToLower();

            if (_data.ContainsKey(word))
            {
                //var result = new List<string>();
                //foreach(var item in _data[word])
                //{
                //    result.Add(item);
                //}

                var result = new List<string>(_data[word]);

                Console.WriteLine($"Successful translation from {DetectLanguage(word)} has been made");
                return result;
            }

            Console.WriteLine("There is no such word in the dictionary");
            return null;
        }
        #endregion


        #region GetStat Method: returns number of english and number of russian words in the Dictionary
        public (int eng, int rus) GetStat()
        {
            int engWordsCount = 0;
            int rusWordsCount = 0;
            foreach (var item in _data.Keys)
            {
                if (DetectLanguage(item) == Language.ENGLISH)
                {
                    engWordsCount++;
                }
                else
                {
                    rusWordsCount++;
                }
            }
            return (engWordsCount, rusWordsCount);
        }
        #endregion


        #region GetStatOfElem(key) Method: returns number of translations of word if it exists in Dictionary
        public int GetStatOfElem(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return 0;
            }

            word = word.Trim().ToLower();
            if (_data.ContainsKey(word))
            {
                return _data[word].Count;
            }
            else
            {
                return 0;
            }
        }
        #endregion


        #region A Method for determining the language of a word
        private static Language DetectLanguage(string text)
        {
            if (Regex.IsMatch(text, @"^[a-zA-Z]+$"))
            {
                return Language.ENGLISH;
            }

            if (Regex.IsMatch(text, @"^[а-яА-ЯёЁ]+$"))
            {
                return Language.RUSSIAN;
            }

            return Language.UNKNOWN;
        }
        #endregion
    }
}

// _data.ContainsKey можно заменить на _data.TryGetValue() - поиск по словарю 1 раз, а не 2 (будет быстрей)
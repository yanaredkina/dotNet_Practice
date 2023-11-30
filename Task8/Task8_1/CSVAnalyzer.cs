using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task8_1
{
    public class CSVAnalyzer
    {
        const string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$";

        // ACCEPTABLE EMAIL PATTERN:
        // yanaredkina@gmail.com
        // yana-redkina@yandex.ru
        // yana.redkina@icloud.com
        // yana@mail.info

        const string phonePattern = @"^(\+7|8)(([\-]\d{3}[\-])|([\(]\d{3}[\)])|(\d{3}))\d{3}[\-]?\d{2}[\-]?\d{2}$";

        // ACCEPTABLE PHONE PATTERN:
        // 89055909422
        // 8(905)5909422
        // 8(905)590-94-22
        // 8-905-5909422
        // 8-905-590-94-22
        // +79055909422
        // +7(905)5909422
        // +7(905)590-94-22
        // +7-905-5909422
        // +7-905-590-94-22


        public static void Start(string filename)
        {
            FileInfo file = new FileInfo(filename);

            if (!file.Exists)
            {
                throw new ArgumentException("ERROR: file doesn't exists");
            }

            if (file.Extension != ".csv")
            {
                throw new ArgumentException("ERROR: a non-csv file");
            }


            var counts = (employee: 0, employeeEmpty: 0,
                          emailCorrect: 0, emailIncorrect: 0, emailEmpty: 0,
                          phoneCorrect: 0, phoneIncorrect: 0, phoneEmpty: 0);

            bool isFirstLine = true;

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();

                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    string[] elements = line.Split('\t');

                    if (elements.Length != 3)
                    {
                        Console.WriteLine("Incorrect line format, the line was excluded from statistics collection:");
                        Console.WriteLine(line);
                        continue;
                    }


                    string name = elements[0].Trim(new char[] { '\'', '\"', ' ' });

                    if (!string.IsNullOrEmpty(name))
                    {
                        counts.employee++;
                    }
                    else
                    {
                        counts.employeeEmpty++;
                    }


                    string email = elements[1].Trim(new char[] { '\'', '\"', ' ' }); ;

                    if (!string.IsNullOrEmpty(email))
                    {

                        if (Regex.IsMatch(email, emailPattern))
                        {
                            counts.emailCorrect++;
                        }
                        else
                        {
                            counts.emailIncorrect++;
                        }
                    }
                    else
                    {
                        counts.emailEmpty++;
                    }


                    string phone = elements[2].Trim(new char[] { '\'', '\"', ' ' });

                    if (!string.IsNullOrEmpty(phone))
                    {

                        if (Regex.IsMatch(phone, phonePattern))
                        {
                            counts.phoneCorrect++;
                        }
                        else
                        {
                            counts.phoneIncorrect++;
                        }
                    }
                    else
                    {
                        counts.phoneEmpty++;
                    }
                }

                Console.WriteLine("RESULTS:");
                Console.WriteLine($"Number of employee records = {counts.employee + counts.employeeEmpty}");
                Console.WriteLine($"\t - Number of employees = {counts.employee}");
                Console.WriteLine($"\t - Number of empty employee data = {counts.employeeEmpty}");

                Console.WriteLine($"Number of email records = {counts.emailCorrect + counts.emailIncorrect + counts.emailEmpty}");
                Console.WriteLine($"\t - Number of correct email = {counts.emailCorrect}");
                Console.WriteLine($"\t - Number of incorrect email = {counts.emailIncorrect}");
                Console.WriteLine($"\t - Number of empty email data: {counts.emailEmpty}");

                Console.WriteLine($"Number of phone records = {counts.phoneCorrect + counts.phoneIncorrect + counts.phoneEmpty}");
                Console.WriteLine($"\t - Number of correct phone = {counts.phoneCorrect}");
                Console.WriteLine($"\t - Number of incorrect phone = {counts.phoneIncorrect}");
                Console.WriteLine($"\t - Number of empty phone data = {counts.phoneEmpty}");

            }

        }
    }
}

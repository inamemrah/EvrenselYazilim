using System;

namespace EvrenselYazilim
{
    class Program
    {
        private int parantez = 0;
        private int susluParantez = 0;
        private int koseliParantez = 0;

        static void Main(string[] args)
        {

            string[] array = new string[] { "(", "a", "e", ")", "[", "[", "r", "{", "e", "m", "r", "}", "]", "]" };

            string[] array2 = new string[] { "(", "[", "e", "m", "r", ")", "]" };

            string[] array3 = new string[] { "[", "(", "]", ")" };

            string[] array4 = new string[] { "[", "[", "r", "{", "e", "m", "r", "}", "]", "]" };

            string[] array5 = new string[] { "[", "[", "r", "{", "e", "m", "r", "}", "]", "]", "]" };

            string[] array6 = new string[] { "e", "m", "r", "{", "[", "6", "}", "]" };

            string[] array7 = new string[] { ")", "e", "[", "r", "]" };

            var program = new Program();
            var result = program.Control(array);

            if(result == true)
            {
                Console.Write("Ýfade Doðru");
            }
            else
            {
                Console.Write("Ýfade Yanlýþ");
            }

            Console.ReadKey();

        }

        public bool Control(string[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] == "(" || array[i] == "[" || array[i] == "{")
                {
                    OpenedParenthesisControl(array[i]);
                }

                else if (array[i] == ")" || array[i] == "]" || array[i] == "}")
                {
                    var result = ClosedParenthesisControl(array[i], i, array);
                    if(result == false)
                    {
                        return false;
                    }
                }
            }

            if (parantez == 0 && susluParantez == 0 && koseliParantez == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OpenedParenthesisControl(string character)
        {
            if (character == "(")
            {
                parantez++;
            }

            else if (character == "[")
            {
                koseliParantez++;
            }

            else if (character == "{")
            {
                susluParantez++;
            }
        }

        public bool ClosedParenthesisControl(string character , int number, string[] array)
        {
            if (character == ")")
            {
                if (parantez == 0)
                {
                    return false;
                }
                else
                {
                    parantez--;
                }

                for (int i = number; i > 0; i--)
                {
                    if(array[i] == "(")
                    {
                        return true;
                    }
                    else if(array[i] == "{")
                    {
                        if(susluParantez != 0)
                        {
                            return false;
                        }
                    }
                    else if(array[i] == "[")
                    {
                        if(koseliParantez != 0)
                        {
                            return false;
                        }
                    }
                }

            }

            else if (character == "]")
            {

                if (koseliParantez == 0)
                {
                    return false;
                }
                else
                {
                    koseliParantez--;
                }

                for (int i = number; i > 0; i--)
                {
                    if (array[i] == "[")
                    {
                        return true;
                    }
                    else if (array[i] == "{")
                    {
                        if (susluParantez != 0)
                        {
                            return false;
                        }
                    }
                    else if (array[i] == "(")
                    {
                        if (parantez != 0)
                        {
                            return false;
                        }
                    }
                }
            }

            else if (character == "}")
            {
                if (susluParantez == 0)
                {
                    return false;
                }
                else
                {
                    susluParantez--;
                }

                for (int i = number; i > 0; i--)
                {
                    if (array[i] == "{")
                    {
                        return true;
                    }
                    else if (array[i] == "[")
                    {
                        if (koseliParantez != 0)
                        {
                            return false;
                        }
                    }
                    else if (array[i] == "(")
                    {
                        if (parantez != 0)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

    }
}

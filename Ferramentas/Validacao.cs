using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramentas
{
    public class Validacao
    {
        public static bool IsCpf(string CPF)
        {
            bool flag = false;
            CPF = CPF.Replace(",", "");
            CPF = CPF.Replace("-", "");
            CPF = CPF.Replace(",", "");
            if (CPF.Trim().Length != 11)
            {
                flag = false;
            }
            else
            {
                int multiplicador = 10;
                int[] num =  new int[11];
                int result = 0;
                for (int i = 0; i <=8; i++)
                {
                    num[i] = Convert.ToInt32(CPF.Substring(i, 1));
                    num[i] = num[i] * multiplicador;
                    result += num[i] ;
                    num[i] = num[i] / multiplicador;
                    multiplicador--;
                }
                result = 11 - (result % 11);
                if (result > 9)
                {
                    num[9] = 0;
                }
                else
                {
                    num[9] = result;
                }
                multiplicador = 11;
                result = 0;
                for (int i = 0; i <= 9; i++)
                {
                    num[i] = num[i] * multiplicador;
                    result += num[i];
                    num[i] = num[i] / multiplicador;
                    multiplicador--;
                }
                result = 11 - (result % 11);
                if (result > 9)
                {
                    num[10] = 0;
                }
                else
                {
                    num[10] = result;
                }
                int nonoDigito = Convert.ToInt32(CPF.Substring(9,1));
                int decDigito = Convert.ToInt32(CPF.Substring(10,1));
                if ((num[9]!=nonoDigito)||(num[10]!=decDigito))
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        public static bool IsCnpj(string CNPJ)
        {
            bool flag = false;
            CNPJ = CNPJ.Replace(",", "");
            CNPJ = CNPJ.Replace("-", "");
            CNPJ = CNPJ.Replace("/", "");
            if (CNPJ.Trim().Length != 14)
            {
                flag = false;
            }
            else
            {
                int multiplicador = 5;
                int[] num = new int[14];
                int result = 0;
                for (int i = 0; i <= 11; i++)
                {
                    num[i] = Convert.ToInt32(CNPJ.Substring(i, 1));
                    num[i] = num[i] * multiplicador;
                    result += num[i];
                    num[i] = num[i] / multiplicador;
                    if (multiplicador == 2 && i == 3)
                    {
                        multiplicador = 9;
                    }
                    else
                    {
                        multiplicador--;
                    }
                }
                if ((result%11) < 2)
                {
                    num[12] = 0;
                }
                else
                {
                    num[12] = 11-(result%11);
                }
                multiplicador = 6;
                result = 0;
                for (int i = 0; i <= 12; i++)
                {
                    num[i] = num[i] * multiplicador;
                    result += num[i];
                    num[i] = num[i] / multiplicador;
                    if (multiplicador == 2 && i == 4)
                    {
                        multiplicador = 9;
                    }
                    else
                    {
                        multiplicador--;
                    }
                }
                if ((result%11)< 2)
                {
                    num[13] = 0;
                }
                else
                {
                    num[13] = 11 - (result % 11);
                }
                int decTerceiroDigito = Convert.ToInt32(CNPJ.Substring(12, 1));
                int decQuartoDigito = Convert.ToInt32(CNPJ.Substring(13, 1));
                if ((num[12] != decTerceiroDigito) || (num[13] != decQuartoDigito))
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        public static bool IsEmail(string email)
        {
            bool flag = false;
            if (email.Contains("@") && email.Contains(".com"))
            {
                flag = true;
            }
            return flag;
        }
    }
}

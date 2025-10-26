using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Classes
{
    public class Constants
    {
        /// <summary>
        /// Максимальная длина Фио абитуриента
        /// </summary>
        public const int FullNameMaxLength = 100;

        /// <summary>
        /// Максимальное кол-во баллов за ЕГЭ
        /// </summary>
        public const int MaxScore = 100;

        /// <summary>
        /// Минимальное кол-во баллов за ЕГЭ
        /// </summary>
        public const int MinScore = 0;
    }
}

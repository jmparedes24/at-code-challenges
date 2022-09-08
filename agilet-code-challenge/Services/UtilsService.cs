using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agilet_code_challenge.Common;
using agilet_code_challenge.Models;

namespace agilet_code_challenge.Services
{
    public class UtilsService : IUtilsService
    {
        public ServiceResponse<string[]> OrganizedArray(string[] names, string[] order)
        {
            ServiceResponse<string[]> response = new ServiceResponse<string[]>();
            try
            {
                string errorMessage;
                if (!AreValidParameters(names, order, out errorMessage))
                    throw new Exception(errorMessage);

                var sortedArray = GetSortedArray(names, order);
                response.Data = sortedArray;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private string[] GetSortedArray(string[] names, string[] order)
        {
            string[] result = new string[names.Length];

            for (int i = 0; i < order.Length; i++)
            {
                int position = 0;
                int.TryParse(order[i], out position);
                result[i] = names[position - 1];
            }

            return result;
        }

        /// <summary>
        /// Methods that will validate information on string arrays lenghts and correct data in order array
        /// </summary>
        /// <param name="names">string[]</param>
        /// <param name="order">string[]</param>
        /// <param name="message">out string</param>
        /// <returns>bool</returns>
        private bool AreValidParameters(string[] names, string[] order, out string message)
        {
            message = string.Empty;
            if (names.Count() == 0)
            {
                message = Consts.ERROR_NAMES_EMPTY;
                return false;
            }

            if (order.Count() == 0)
            {
                message = Consts.ERROR_ORDER_EMPTY;
                return false;
            }


            if (names.Count() != order.Count())
            {
                message = Consts.ERROR_DIFFERENT_LENGTH;
                return false;
            }

            if (!IsOrderCorrect(order, names.Length))
            {
                message = Consts.ERROR_ORDER_INCORRECT;
                return false;
            }


            return true;
        }

        /// <summary>
        /// Method that validates if the order array has the correct order and numbers
        /// </summary>
        /// <param name="order">string[]</param>
        /// <param name="namesLength">int</param>
        /// <returns>bool</returns>
        private bool IsOrderCorrect(string[] order, int namesLength)
        {

            int[] arr = new int[namesLength + 1];
            for (int i = 0; i < order.Length; i++)
            {
                int position = 0;
                if (!int.TryParse(order[i], out position))
                    return false;
                arr[position] += 1;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != 1)
                    return false;
            }
            return true;
        }
    }
}
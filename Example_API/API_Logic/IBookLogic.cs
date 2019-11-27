﻿using API_Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Logic
{
    public interface IBookLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResultType Delete(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        ResultType Update(string id, Book info);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        List<Book> Search(IDictionary<string, string> conditions);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetCount(IDictionary<string, string> conditions);
    }
}

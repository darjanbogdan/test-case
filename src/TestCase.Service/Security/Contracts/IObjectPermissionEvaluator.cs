﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Service.Security.Contracts
{
    /// <summary>
    /// Object permission evaluator contract.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectPermissionEvaluator<T>
    {
        /// <summary>
        /// Asynchronously evaluates the object permissions for given model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<bool> EvaluateAsync(T model);
    }
}

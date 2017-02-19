// ----------------------------------------------------------------------------
// <copyright file="IDataService.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.PracticalMvvm.DataAccess
{
    using System;
    using System.Threading.Tasks;
    using SogetiSpain.PracticalMvvm.Model;

    /// <summary>
    /// Defines the contract for a data service.
    /// </summary>
    public interface IDataService : IDisposable
    {
        #region Methods

        /// <summary>
        /// Gets an employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>
        /// The retrieved employee.
        /// </returns>
        Task<Employee> GetEmployeeByIdAsync(int employeeId);

        /// <summary>
        /// Saves a given employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// A task.
        /// </returns>
        Task SaveEmployeeAsync(Employee employee);

        #endregion Methods
    }
}
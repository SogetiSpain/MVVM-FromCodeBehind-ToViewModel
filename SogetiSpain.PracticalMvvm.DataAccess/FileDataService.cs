// ----------------------------------------------------------------------------
// <copyright file="FileDataService.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.PracticalMvvm.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using SogetiSpain.PracticalMvvm.Model;

    /// <summary>
    /// Represents a file data service.
    /// </summary>
    public class FileDataService : IDataService
    {
        #region Fields

        /// <summary>
        /// Defines the storage file.
        /// </summary>
        private const string StorageFile = "Employees.json";

        #endregion Fields

        #region Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets an employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>
        /// The retrieved employee.
        /// </returns>
        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            List<Employee> employees = await this.ReadFromFileAsync().ConfigureAwait(false);
            Employee employee = employees.Single(e => (e.Id == employeeId));

            return employee;
        }

        /// <summary>
        /// Saves a given employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// A task.
        /// </returns>
        public async Task SaveEmployeeAsync(Employee employee)
        {
            List<Employee> employees = await this.ReadFromFileAsync().ConfigureAwait(false);

            Employee existing = employees.Single(e => (e.Id == employee.Id));
            int indexOfExisting = employees.IndexOf(existing);
            employees.Insert(indexOfExisting, employee);
            employees.Remove(existing);

            await this.SaveToFileAsync(employees).ConfigureAwait(false);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="FileDataService" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        ///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            // Usually Service-Proxies are disposable.
            // This method is added as demo-purpose to show how to use an IDisposable in the client.
        }

        /// <summary>
        /// Reads all employees from the file.
        /// </summary>
        /// <returns>
        /// A list containing all retrieved employees.
        /// </returns>
        private async Task<List<Employee>> ReadFromFileAsync()
        {
            List<Employee> allEmployees;

            if (!File.Exists(StorageFile))
            {
                allEmployees = new List<Employee>
                {
                    new Employee
                    {
                        Address = "Avda. España, 12",
                        City = "Fuenlabrada",
                        State = "Madrid",
                        Country = "Spain",
                        PostalCode = "28940",
                        Email = "antonio.lopez@nomail.com",
                        FirstName = "Antonio",
                        HireDate = new DateTime(2017, 1, 1),
                        Id = 1,
                        LastName = "López",
                        Phone = "606 60 60 60",
                    },
                    new Employee
                    {
                        Address = "Avda. Tenerife, 34",
                        City = "Fuenlabrada",
                        State = "Madrid",
                        Country = "Spain",
                        PostalCode = "28940",
                        Email = "marta.fernandez@nomail.com",
                        FirstName = "Marta",
                        HireDate = new DateTime(2017, 1, 2),
                        Id = 2,
                        LastName = "Fernández",
                        Phone = "604 40 40 40",
                    },
                    new Employee
                    {
                        Address = "Avda. Andalucia, 23",
                        City = "Fuenlabrada",
                        State = "Madrid",
                        Country = "Spain",
                        PostalCode = "28940",
                        Email = "alvaro.torres@nomail.com",
                        FirstName = "Álvaro",
                        HireDate = new DateTime(2017, 1, 3),
                        Id = 3,
                        LastName = "Torres",
                        Phone = "605 50 50 50",
                    },
                    new Employee
                    {
                        Address = "Avda. Extremadura, 23",
                        City = "Fuenlabrada",
                        State = "Madrid",
                        Country = "Spain",
                        PostalCode = "28940",
                        Email = "gema.sanchez@nomail.com",
                        FirstName = "Gema",
                        HireDate = new DateTime(2017, 1, 4),
                        Id = 4,
                        LastName = "Sánchez",
                        Phone = "605 50 50 50",
                    },
                };

                await Task.Yield();
            }
            else
            {
                allEmployees = await Task.Run<List<Employee>>(() =>
                {
                    string json = File.ReadAllText(FileDataService.StorageFile);
                    return JsonConvert.DeserializeObject<List<Employee>>(json);
                })
                .ConfigureAwait(false);
            }

            return allEmployees;
        }

        /// <summary>
        /// Saves the given employees to the file.
        /// </summary>
        /// <param name="employees">The employees.</param>
        /// <returns>
        /// A task.
        /// </returns>
        private async Task SaveToFileAsync(List<Employee> employees)
        {
            await Task.Run(() =>
            {
                string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
                File.WriteAllText(StorageFile, json);
            })
            .ConfigureAwait(false);
        }

        #endregion Methods
    }
}
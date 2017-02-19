// ----------------------------------------------------------------------------
// <copyright file="EmployeeEditViewModel.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.PracticalMvvm.Demo3.ViewModels
{
    using System.Windows.Input;
    using Prism.Commands;
    using Prism.Mvvm;
    using SogetiSpain.PracticalMvvm.DataAccess;
    using SogetiSpain.PracticalMvvm.Model;

    /// <summary>
    /// Represents the view model for Employee edit view.
    /// </summary>
    public class EmployeeEditViewModel : BindableBase
    {
        #region Fields

        /// <summary>
        /// Defines the employee.
        /// </summary>
        private Employee employee;

        /// <summary>
        /// Defines the value indicating whether the view is enabled.
        /// </summary>
        private bool isEnabled;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeEditViewModel"/> class.
        /// </summary>
        public EmployeeEditViewModel()
        {
            this.SaveCommand = new DelegateCommand(this.OnSave);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public Employee Employee
        {
            get
            {
                return this.employee;
            }

            set
            {
                if (this.employee != value)
                {
                    this.employee = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the view is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the view is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }

            set
            {
                if (this.isEnabled != value)
                {
                    this.isEnabled = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        /// <value>
        /// The save command.
        /// </value>
        public ICommand SaveCommand
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Loads an employee.
        /// </summary>
        public async void LoadEmployee()
        {
            this.IsEnabled = false;

            this.Employee = null;
            using (IDataService service = new FileDataService())
            {
                this.Employee = await service.GetEmployeeByIdAsync(this.EmployeeId);
            }

            this.IsEnabled = true;
        }

        /// <summary>
        /// Called when the user requests save data.
        /// </summary>
        private async void OnSave()
        {
            this.IsEnabled = false;

            using (IDataService service = new FileDataService())
            {
                await service.SaveEmployeeAsync(this.Employee);
            }

            this.IsEnabled = true;
        }

        #endregion Methods
    }
}
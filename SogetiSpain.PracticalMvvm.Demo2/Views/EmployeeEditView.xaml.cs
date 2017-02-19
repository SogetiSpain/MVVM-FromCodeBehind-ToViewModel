// ----------------------------------------------------------------------------
// <copyright file="EmployeeEditView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.PracticalMvvm.Demo2.Views
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using SogetiSpain.PracticalMvvm.DataAccess;
    using SogetiSpain.PracticalMvvm.Model;

    /// <summary>
    /// Interaction logic for Employee edit view.
    /// </summary>
    public partial class EmployeeEditView : UserControl
    {
        #region Fields

        /// <summary>
        /// Defines the employee identifier property.
        /// </summary>
        private static readonly DependencyProperty EmployeeIdProperty =
            DependencyProperty.Register(
                "EmployeeId",
                typeof(int),
                typeof(EmployeeEditView),
                new PropertyMetadata(default(int)));

        /// <summary>
        /// Defines the employee.
        /// </summary>
        private Employee employee;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeEditView"/> class.
        /// </summary>
        public EmployeeEditView()
        {
            this.InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId
        {
            get
            {
                return (int)this.GetValue(EmployeeEditView.EmployeeIdProperty);
            }

            set
            {
                this.SetValue(EmployeeEditView.EmployeeIdProperty, value);
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Called when this instance is loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            this.Cursor = Cursors.Wait;
            this.IsEnabled = false;

            this.employee = null;
            using (IDataService service = new FileDataService())
            {
                this.employee = await service.GetEmployeeByIdAsync(this.EmployeeId);
            }

            this.Cursor = Cursors.None;
            this.IsEnabled = true;

            if (this.employee == null)
            {
                return;
            }

            this.DataContext = this.employee;
        }

        /// <summary>
        /// Called when the user requests save data.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void OnSave(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;

            using (IDataService service = new FileDataService())
            {
                await service.SaveEmployeeAsync(this.employee);
            }

            this.IsEnabled = true;
        }

        #endregion Methods
    }
}
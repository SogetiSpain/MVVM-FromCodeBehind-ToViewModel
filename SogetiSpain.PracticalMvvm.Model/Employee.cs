// ----------------------------------------------------------------------------
// <copyright file="Employee.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.PracticalMvvm.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents an employee entity.
    /// </summary>
    public class Employee : IEquatable<Employee>
    {
        #region Fields

        /// <summary>
        /// Defines the cached hash code.
        /// </summary>
        private int? cachedHashCode;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [Required]
        [StringLength(70)]
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public DateTime? BirthDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [Required]
        [StringLength(40)]
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [Required]
        [StringLength(40)]
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [StringLength(60)]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>
        /// The fax.
        /// </value>
        [StringLength(24)]
        public string Fax
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        [StringLength(20)]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the hire date.
        /// </summary>
        /// <value>
        /// The hire date.
        /// </value>
        public DateTime? HireDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        [StringLength(20)]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        [StringLength(24)]
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        [Required]
        [StringLength(10)]
        public string PostalCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [Required]
        [StringLength(40)]
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [StringLength(30)]
        public string Title
        {
            get;
            set;
        }

        #endregion Properties

        #region Operators

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Employee operand1, Employee operand2)
        {
            return !(operand1 == operand2);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Employee operand1, Employee operand2)
        {
            return object.Equals(operand1, operand2);
        }

        #endregion Operators

        #region Methods

        /// <summary>
        /// Determines whether the specified instance, is equal to this instance.
        /// </summary>
        /// <param name="other">The instance to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified instance is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Employee other)
        {
            return base.Equals(other);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as Employee;

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            if ((other == null) || !(other is Employee))
            {
                return false;
            }

            if (this.IsTransient())
            {
                return false;
            }

            return this.HasSameNonDefaultIdAs(other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            if (this.cachedHashCode.HasValue)
            {
                return this.cachedHashCode.Value;
            }

            if (this.IsTransient())
            {
                this.cachedHashCode = base.GetHashCode();
            }
            else
            {
                unchecked
                {
                    int hashCode = this.GetType().GetHashCode();
                    this.cachedHashCode = (hashCode * 33) ^ this.Id.GetHashCode();
                }
            }

            return this.cachedHashCode.Value;
        }

        /// <summary>
        /// Determines whether this instance is transient.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is transient; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTransient()
        {
            return this.Id.Equals(0L);
        }

        /// <summary>
        /// Determines whether this instance has the same non default identifier as the specified instance.
        /// </summary>
        /// <param name="other">The instance to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if this instance has the same non default identifier; otherwise, <c>false</c>.
        /// </returns>
        private bool HasSameNonDefaultIdAs(Employee other)
        {
            return !this.IsTransient() && !other.IsTransient() && this.Id.Equals(other.Id);
        }

        #endregion Methods
    }
}
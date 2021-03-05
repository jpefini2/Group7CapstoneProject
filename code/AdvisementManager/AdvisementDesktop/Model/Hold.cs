using System;

namespace AdvisementDesktop.Model
{
    /// <summary>
    ///   The holds class for managing a students hold
    /// </summary>
    public class Hold
    {
        /// <summary>Gets or sets the unique identifier for the hold.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the reason for the hold.</summary>
        /// <value>The reason.</value>
        public string Reason { get; set; }

        /// <summary>Gets or sets the date the hold was applied.</summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets a value indicating whether the hold is active.</summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

    }
}

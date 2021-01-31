using System;

namespace AdvisementManagerDesktopApp.Model
{
    /// <summary>
    ///   The holds class
    /// </summary>
    public class Hold
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the reason.</summary>
        /// <value>The reason.</value>
        public string Reason { get; set; }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

    }
}

namespace Spartane.Core.Domain.Binnacle
{
    public class DashBoardData : BaseEntity
    {
        /// <summary>
        /// Gets or Sets description of the DashBoard
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or Sets the key of the DashBoard
        /// </summary>
        public int? Key{ get; set; }
    }
}

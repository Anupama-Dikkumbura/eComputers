using System;
namespace eComputer.Models
{
	public class ComModel_Accessory
	{
		public int ComModelId { get; set; }
		public ComModel ComModel { get; set; }

		public int AccessoryId { get; set; }
		public Accessory Accessory { get; set; }
	}
}

